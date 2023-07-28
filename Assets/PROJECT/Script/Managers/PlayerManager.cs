using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    #region Variables
    #region Player GameObject Properties
    [Header("Player GO Properties")]
    [SerializeField]
    private GameObject _playerAvatar;
    [SerializeField]
    private Transform _playerRootCam;
    public CinemachineVirtualCamera playerCam;

    private PlayerInput _playerInput;
    private Animator _animator;
    private CharacterController _controller;

    private bool _hasAnimator;
    #endregion

    #region Cinemachine
    [Header("Camera Options")]
    [SerializeField]
    private float TopClamp = 70.0f;
    [SerializeField]
    private float BottomClamp = -30.0f;
    [SerializeField]
    private float _playerYaw;
    [SerializeField]
    private float _playerPitch;
    private const float _threshold = 0.01f;
    #endregion

    #region Movement 
    [Header("Movement Settings")]
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _sprintSpeed;
    [SerializeField]
    [Range(0.0f, 0.3f)]
    private float _rotationSmoothTime;
    [SerializeField]
    private float _speedChangeRate;

    [Header("Player Movement")]
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _targetRotation;
    [SerializeField]
    private float _rotationVelocity;
    [SerializeField]
    private float _verticalVelocity;

    #endregion


    #endregion

    private void OnEnable()
    {
        _playerAvatar = AvatarManager.Instance.selectedAvatar;
        _playerRootCam = _playerAvatar.transform.Find("PlayerCameraRoot");
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerYaw = _playerRootCam.rotation.eulerAngles.y;

        //_playerAvatar = AvatarManager.Instance.selectedAvatar;
        _animator = _playerAvatar.GetComponent<Animator>();
        _controller = _playerAvatar.GetComponent<CharacterController>();
        _playerInput = _playerAvatar.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraRotation();
    }

    #region Cinemachine
    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;

        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    private void CameraRotation()
    {
        //Don't multiply mouse input by Time.deltaTime
        if(InputManager.Instance.look.sqrMagnitude >= _threshold)
        {
            float deltaTimeMultiplier = 1.0f;

            _playerYaw += InputManager.Instance.look.x * deltaTimeMultiplier;
            _playerPitch += InputManager.Instance.look.y * deltaTimeMultiplier;
        }

        //clamp rotations so values are limited 360 degrees
        _playerYaw = ClampAngle(_playerYaw, float.MinValue, float.MaxValue);
        _playerPitch = ClampAngle(_playerPitch, BottomClamp, TopClamp);

        //Cinemachine will follow this target
        _playerRootCam.rotation = Quaternion.Euler(_playerPitch, _playerYaw, 0.0f);
    }
    #endregion

    #region Movement
    private void Move()
    {
        float targetSpeed = InputManager.Instance.isSprinting ? _sprintSpeed : _moveSpeed;

        if (InputManager.Instance.move == Vector2.zero)
            targetSpeed = 0.0f;

        float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

        float speedOffset = 0.1f;
        float inputMagnitude = InputManager.Instance.analogMovement ? InputManager.Instance.move.magnitude : 1f;

        if(currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * _speedChangeRate);
            _speed = Mathf.Round(_speed * 1000f) / 1000f;
        }
        else
        {
            _speed = targetSpeed;
        }

        Vector3 inputDirection = new Vector3(InputManager.Instance.move.x, 0.0f, InputManager.Instance.move.y).normalized;

        if(InputManager.Instance.move != Vector2.zero)
        {
            _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + playerCam.transform.eulerAngles.y;

            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, _rotationSmoothTime);

            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }

        Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

        _controller.Move(targetDirection.normalized * (_speed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
    }

    #endregion
}
