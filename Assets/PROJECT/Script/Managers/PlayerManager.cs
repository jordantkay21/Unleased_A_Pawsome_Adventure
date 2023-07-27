using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]

public class PlayerManager : MonoSingleton<PlayerManager>
{
    [Header("Player Properties")]
    [SerializeField]
    private Transform _playerAvatar;
    public CinemachineVirtualCamera playerCam;

    private PlayerInput _playerInput;
    private Animator _animator;
    private CharacterController _controller;

    private bool _hasAnimator;

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

    // Start is called before the first frame update
    void Start()
    {
        _playerYaw = _playerAvatar.rotation.eulerAngles.y;

        //_playerAvatar = AvatarManager.Instance.selectedAvatar;
        _hasAnimator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerAvatar = AvatarManager.Instance.selectedAvatar.transform.Find("PlayerCameraRoot");
    }

    private void LateUpdate()
    {
        CameraRotation();
    }

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
        _playerAvatar.rotation = Quaternion.Euler(_playerPitch, _playerYaw, 0.0f);
    }
}
