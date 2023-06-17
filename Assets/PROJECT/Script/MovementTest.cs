using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementTest : MonoBehaviour
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
        _direction = move;
    }
    private void CalculateMovement()
    {
        SetMaxSpeed();
        CalculateSpeed();
        CalculateTurn();

        _isWalking = CheckIsWalking();

        transform.Translate(new Vector3(_direction.x, 0, _direction.y) * _currentSpeed);
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

    private IEnumerator TurnAnimationRoutine(int degree)
    {
        _anim.SetInteger("TurnAngle_int", degree);
        yield return new WaitForSeconds(.5f);

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

    private bool CheckIsWalking()
    {
        if (_direction.x == 0f && _direction.y == 0f)
            return false;
        else
            return true;
    }
    private void CalculateSpeed()
    {

        if (_currentSpeed < _maxSpeed)
            _currentSpeed += Time.deltaTime;
        if (_currentSpeed > _maxSpeed)
            _currentSpeed -= Time.deltaTime;
        if (_currentSpeed < 0.0f)
            _currentSpeed = 0;

    }

    private void CalculateTurn()
    {
        if (_direction.x < 0)
        {
            if (_currentSpeed < .51f)
                transform.Rotate(Vector3.up * Time.deltaTime * -45, Space.Self);
            else if (_currentSpeed > .50)
                transform.Rotate(Vector3.up * Time.deltaTime * -65, Space.Self);
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
