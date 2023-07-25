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
    public GameObject playerAvater;
    public CinemachineVirtualCamera playerCam;

    private PlayerInput _playerInput;
    private Animator _animator;
    private CharacterController _controller;

    private bool _hasAnimator;

    private bool IsCurrentDeviceMouse
    {
        get
        {
#if ENABLE_INPUT_SYSTEM
            return _playerInput.currentControlScheme == "KeyboardMouse";
#else 
            return false;
#endif
        }
    }

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
        _playerYaw = playerAvater.transform.rotation.eulerAngles.y;
        _hasAnimator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CameraRotation()
    {
        if()
    }
}
