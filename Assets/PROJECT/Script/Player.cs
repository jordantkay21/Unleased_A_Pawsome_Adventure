using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoSingleton<Player>
{
    [SerializeField]
    private Vector2 _move;
    [SerializeField]
    private float _currentSpeed;
    [SerializeField]
    private float _maxSpeed;
    private float _maxWalk = 0.5f;
    private float _maxRun = 1.0f;
    private float _acceleration = 1;
    private float _decelleration = 1;

    public bool isRunning;
    [SerializeField]
    private bool _isWalking;
    [SerializeField]
    private bool _isIdle;

    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        if (_anim == null)
            Debug.LogError("Player failed to connect Animator");
    }

    private void Update()
    {
        CalculateMovement();
        _anim.SetFloat("Movement_f", _currentSpeed);
    }

    #region Movement
    public void SetMovement(Vector2 move)
    {
        _move = move;
    }
    private void CalculateMovement()
    {
        SetMaxSpeed();
        SetIdle();
        CalculateSpeed();
        CalculateTurn();

        transform.Translate(new Vector3(_move.x, 0, _move.y) * _currentSpeed);
    }

    private void SetMaxSpeed()
    {
        if (isRunning && _isWalking)
            _maxSpeed = _maxRun;
        else if (!isRunning && _isWalking)
            _maxSpeed = _maxWalk;
        else if (!_isWalking && isRunning)
            _maxSpeed = 0.0f;
        else
            _maxSpeed = 0.0f;

        if (_maxSpeed <= 0.0f)
            _isIdle = true;
        else
            _isIdle = false;
            
    }

    private IEnumerator TurnLeftRoutine()
    {
        _anim.SetInteger("TurnAngle_int", -90);
        yield return new WaitForSeconds(.5f);
        _anim.SetInteger("TurnAngle_int", 0);
    }

    private IEnumerator TurnRightRoutine()
    {
        _anim.SetInteger("TurnAngle_int", 90);
        yield return new WaitForSeconds(.5f);
        _anim.SetInteger("TurnAngle_int", 0);
    }

    private IEnumerator TurnAroundRoutine()
    {
        _anim.SetInteger("TurnAngle_int", 180);
        yield return new WaitForSeconds(.5f);
        _anim.SetInteger("TurnAngle_int", 0);
    }

    private void SetIdle()
    {
        if (_move.x == 0f && _move.y == 0f)
            _isWalking = false;
        else
            _isWalking = true;

    }
    private void CalculateSpeed()
    {

        if (_currentSpeed < _maxSpeed)
            _currentSpeed += Time.deltaTime * _acceleration;
        if (_currentSpeed > _maxSpeed && !isRunning)
            _currentSpeed -= Time.deltaTime * _decelleration;
        if (_currentSpeed > _maxSpeed && !_isWalking && isRunning)
            _currentSpeed -= Time.deltaTime * _decelleration;
        if (_currentSpeed > 0.0f && !_isWalking)
            _currentSpeed -= Time.deltaTime * _decelleration;
        if (_currentSpeed < 0.0f)
            _currentSpeed = 0;

    }

    private void CalculateTurn()
    {
        if(_move.x < 0)
        {
            if (_currentSpeed < .51f)
                transform.Rotate(Vector3.up * Time.deltaTime * -45, Space.Self);
            else if (_currentSpeed > .50)
                transform.Rotate(Vector3.up * Time.deltaTime * -65, Space.Self);     
        }

        if(_move.x > 0)
        {
            if (_currentSpeed < .51f)
                transform.Rotate(Vector3.up * Time.deltaTime * 45, Space.Self);
            else if (_currentSpeed > .50)
                transform.Rotate(Vector3.up * Time.deltaTime * 65, Space.Self);
        }

        if (_isIdle && Keyboard.current.aKey.wasPressedThisFrame)
        {
            _maxSpeed = 0.0f;
            StartCoroutine(TurnLeftRoutine());
        }

        if (_isIdle && Keyboard.current.dKey.wasPressedThisFrame)
        {
            _maxSpeed = 0.0f;
            StartCoroutine(TurnRightRoutine());
        }

        if (_isIdle && Keyboard.current.sKey.wasPressedThisFrame)
        {
            _maxSpeed = 0.0f;
            StartCoroutine(TurnAroundRoutine());
        }
    }

    #endregion
}
