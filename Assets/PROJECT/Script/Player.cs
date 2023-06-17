using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoSingleton<Player>
{
    [SerializeField]
    private Vector2 _direction;
    [SerializeField]
    private float _currentSpeed;
    [SerializeField]
    private float _maxSpeed;
    private float _maxWalk = 0.5f;
    private float _maxRun = 1.0f;

    public bool isRunning;
    [SerializeField]
    private bool _isWalking;
    private bool _isIdle;

    private Animator _anim;

    
    private void Start()
    {
        _anim = GetComponent<Animator>();
        if (_anim == null)
            Debug.LogError("Player failed to connect Animator");
    }

    void Update()
    {
        CalculateMovement();
    }

    #region Movement
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
    private void CalculateMovement()
    {
        SetMaxSpeed();
        CalculateCurrentSpeed();
        CalculateTurn();

        _isWalking = CheckIsWalking();

        transform.Translate(new Vector3(_direction.x, 0, _direction.y) * _currentSpeed);
        _anim.SetFloat("Movement_f", _currentSpeed);
    }

    private void SetMaxSpeed()
    {
        if (isRunning && _isWalking)
            _maxSpeed = _maxRun;
        else if (!isRunning && _isWalking)
            _maxSpeed = _maxWalk;
        else
            _maxSpeed = 0.0f;

        if (_maxSpeed <= 0.0f)
            _isIdle = true;
        else
            _isIdle = false;
    }

    private bool CheckIsWalking()
    {
        if (_direction.x == 0f && _direction.y == 0f)
            return false;
        else
            return true;

    }
    private void CalculateCurrentSpeed()
    {
        if (_currentSpeed < _maxSpeed)
            _currentSpeed += Time.deltaTime;
        if (_currentSpeed > _maxSpeed && !isRunning)
            _currentSpeed -= Time.deltaTime;
        if (_currentSpeed > 0.0f && !_isWalking)
            _currentSpeed -= Time.deltaTime;
        if (_currentSpeed < 0.0f)
            _currentSpeed = 0;
    }

    private IEnumerator TurnAnimationRoutine(int degree)
    {
        _anim.SetInteger("TurnAngle_int", degree);
        yield return new WaitForSeconds(.5f);
        _anim.SetInteger("TurnAngle_int", 0);
    }

    private void CalculateTurn()
    {
        if (_direction.x < 0)
        {
            if (_currentSpeed < .51f)
                transform.Rotate(Vector3.up * Time.deltaTime * -45);
            else if (_currentSpeed > .50)
                transform.Rotate(Vector3.up * Time.deltaTime * -65);
        }

        if (_direction.x > 0)
        {
            if (_currentSpeed < .51f)
                transform.Rotate(Vector3.up * Time.deltaTime * 45, Space.Self);
            else if (_currentSpeed > .50)
                transform.Rotate(Vector3.up * Time.deltaTime * 65, Space.Self);
        }

        if (_isIdle && Keyboard.current.aKey.wasPressedThisFrame)
        {
            _maxSpeed = 0.0f;
            StartCoroutine(TurnAnimationRoutine(-90));
        }

        if (_isIdle && Keyboard.current.dKey.wasPressedThisFrame)
        {
            _maxSpeed = 0.0f;
            StartCoroutine(TurnAnimationRoutine(90));
        }

        if (_isIdle && Keyboard.current.sKey.wasPressedThisFrame)
        {
            _maxSpeed = 0.0f;
            StartCoroutine(TurnAnimationRoutine(180));
        }

    }

    #endregion
}
