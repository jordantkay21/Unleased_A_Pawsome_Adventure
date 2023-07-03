using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoSingleton<Player>
{
    [Header("Direction")]
    [SerializeField]
    private Vector2 _directionInput;

    [Header("Speed")]
    [SerializeField]
    private float _currentSpeed;
    [SerializeField]
    private float _maxSpeed;

    [Space(10)]

    [SerializeField]
    private float _maxWalk = 0.05f;
    [SerializeField]
    private float _maxRun = .075f;

    [Header("Gravity")]
    [Tooltip("Useful for rough ground")]
    [SerializeField]
    private float _groundOffset = -0.14f;
    [Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
    [SerializeField]
    private float _groundedRadius = 0.2f;
    [Tooltip("What layers the character uses as ground")]
    [SerializeField]
    private LayerMask _groundedLayers;
    [Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
    [SerializeField]
    private float _gravity = -9;

    [Space(10)]
    
    [Tooltip("Time required to pass before entering into a fall state. Usefull fow walking down stairs")]
    [SerializeField]
    private float _fallTimeout = 0.15f;
    [Tooltip("Used to calculate the ammount of time passed while falling")]
    [SerializeField]
    private float _fallTimeCalc;
    [Tooltip("Maximum speed the character can travel while free falling.")]
    [SerializeField]
    private float _terminalVelocity = 53.0f;
    [Tooltip("Refers to the speed at which the character can move vertically")]
    [SerializeField]
    private float _verticalVelocity;

    [Space(10)]

    [Tooltip("Value the _fallTimeCalc needs to be under to set off Soft Landing Animation")]
    [SerializeField]
    private float _landSoftAnimValue;
    [Tooltip("_fallTimeCalc must be between this value and _landsoftAnimValue to set off Medium Landing Animation")]
    [SerializeField]
    private float _landMediumAnimValue;


    [Header("Jump")]
    [Tooltip("The height the player can jump")]
    [SerializeField]
    private float _jumpHeight = 1.2f;
    [Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
    [SerializeField]
    private float _jumpTimeout = 0.5f;
    [Tooltip("Used to calculate the ammount of time passed between jumps")]
    [SerializeField]
    private float _jumpTimeCalc;
    [Tooltip("Used to delay vertical incline until it matches with animation")]
    [SerializeField]
    private float _jumpDelay = 3;
    
    [Header("State Controls")]
    [SerializeField]
    public bool isRunning;
    [SerializeField]
    private bool _isWalking;
    [SerializeField]
    private bool _isIdle;
    [SerializeField]
    private bool _isJumping;
    [SerializeField]
    private bool _isGrounded = true;
    [SerializeField]
    private bool _performingAction = false;

    [Header("Components")]
    private Animator _anim;
    private CharacterController _controller;

    #region System Methods
    private void Start()
    {
        _groundedLayers = LayerMask.GetMask("Ground");

        _anim = GetComponent<Animator>();
        if (_anim == null)
            Debug.LogError("Player failed to connect Animator");

        _controller = GetComponent<CharacterController>();
        if (_controller == null)
            Debug.LogError("Player failed to connect to Character Controller");
    }

    void Update()
    {
        CalculateMovement();
    }

    private void FixedUpdate()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 velocity = new Vector3(0.0f, _verticalVelocity, 0.0f);
        float curSpeed = _currentSpeed * Input.GetAxis("Vertical");
        _controller.Move((forward * curSpeed) + (velocity * Time.deltaTime));
        JumpingAndFalling();
    }
    #endregion

    #region Movement
    private void CalculateMovement()
    {
        CalculateTurn();
        CalculateCurrentSpeed();
        SetMaxSpeed();
        _isWalking = CheckIsWalking();

        _anim.SetFloat("Movement_f", _currentSpeed);
    }

    #region Walking
    public void SetDirection(Vector2 direction)
    {
        _directionInput = direction;
    }

    private void SetMaxSpeed()
    {
        if (!_performingAction)
        {
            if (isRunning && _isWalking)
                _maxSpeed = _maxRun;
            else if (!isRunning && _isWalking)
                _maxSpeed = _maxWalk;
            else
                _maxSpeed = 0.0f;
        }
        else
            _maxSpeed = 0.0f;

        if (_maxSpeed <= 0.0f)
            _isIdle = true;
        else
            _isIdle = false;
    }

    private bool CheckIsWalking()
    {
        if (_directionInput.x == 0f && _directionInput.y == 0f)
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
        if (_directionInput.x < 0 && !_performingAction) 
        {
            if (_currentSpeed < .05f)
                transform.Rotate(Vector3.up * Time.deltaTime * -45);
            else if (_currentSpeed > .06)
                transform.Rotate(Vector3.up * Time.deltaTime * -65);
        }

        if (_directionInput.x > 0 && !_performingAction)
        {
            if (_currentSpeed < .05f)
                transform.Rotate(Vector3.up * Time.deltaTime * 45, Space.Self);
            else if (_currentSpeed > .06)
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

    #region Jumping & Gravity

    private bool GroundCheck()
    {
        //set Sphere position, with offset
        Vector3 spherePos = new Vector3(transform.position.x, transform.position.y - _groundOffset, transform.position.z);

        _isGrounded = Physics.CheckSphere(spherePos, _groundedRadius, _groundedLayers, QueryTriggerInteraction.Ignore);

        return _isGrounded;
    }
    
    public void IsJumping()
    {
        if (!_performingAction)
        {
            _isJumping = true;
        }
    }
    
    private IEnumerator JumpingRoutine()
    {
        _anim.SetTrigger("Jump_tr");
        _isJumping = false;

        yield return new WaitForSeconds(0.2f);
        //the square root of Height * -2 * Gravity = how much velocity needed to reach desired height
        _verticalVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity);

    }
    
    private void JumpingAndFalling()
    {
        if (GroundCheck())
        {
            _anim.SetBool("Grounded_b", true);
            _fallTimeCalc = _fallTimeout;


            if (_verticalVelocity < 0.0f)
                _verticalVelocity = -2f;

            if (_isJumping && _jumpTimeCalc <= 0.0f)
            {
                StartCoroutine(JumpingRoutine());
            }

            if (_jumpTimeCalc >= 0.0f)
                _jumpTimeCalc -= Time.deltaTime;
        }
        else
        {
            _jumpTimeCalc = _jumpTimeout;
            
            if (_fallTimeCalc >= 0.0f)
                _fallTimeCalc -= Time.deltaTime;
            else
            {
                _anim.SetBool("Grounded_b", false);
            }
        }
        
        //apply gravity over time if under terminal velocity
        if (_verticalVelocity < _terminalVelocity)
            _verticalVelocity += _gravity * Time.deltaTime; 
    }

    #endregion

    #region Actions

    public void Bark()
    {
        if (_isIdle) 
            StartCoroutine(ActionRoutine(1, 2.9f)); 
    }

    private IEnumerator ActionRoutine(int ActionType, float AnimationTime) 
    {
        _performingAction = true;
        _anim.SetInteger("ActionType_int", ActionType);
        yield return new WaitForSeconds(AnimationTime);
        _anim.SetInteger("ActionType_int", 0);
        _performingAction = false;
    }

    public void Dig()
    {
        if(_isIdle)
            StartCoroutine(ActionRoutine(4, 5.6f)); 
    }

    #endregion
    #endregion


}