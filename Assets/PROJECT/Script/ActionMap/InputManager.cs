using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoSingleton<InputManager>
{
    private GameInputActions _input;

    [Header("Player Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool isJumping;
    public bool isSprinting;
    public bool isDigging;
    public bool isBarking;

    [Header("Movement Settings")]
    public bool analogMovement;

    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
    public bool cursorInputForLook = true;

    // Start is called before the first frame update
    void Start()
    {
        InitializeInputs();
    }

    private void Update()
    {
        MoveInput();
        LookInput();
    }

    private void InitializeInputs()
    {
        _input = new GameInputActions();
        _input.CharacterSelection.Enable();

        _input.CharacterSelection.IncreaseCurrentCam.performed += IncreaseCurrentCam_performed;
        _input.CharacterSelection.DecreaseCurrentCam.performed += DecreaseCurrentCam_performed;
        _input.CharacterSelection.ChooseCharacter.performed += ChooseCharacter_performed;
        
        _input.PlayerActions.Running.performed += Running_performed;
        _input.PlayerActions.Running.canceled += Running_canceled;
        _input.PlayerActions.Jump.performed += Jump_performed;
        _input.PlayerActions.Jump.canceled += Jump_canceled;
        _input.PlayerActions.Bark.performed += Bark_performed;
        _input.PlayerActions.Bark.canceled += Bark_canceled;
        _input.PlayerActions.Dig.performed += Dig_performed;
        _input.PlayerActions.Dig.canceled += Dig_canceled;

    }



    #region Character Selection Actions
    private void ChooseCharacter_performed(InputAction.CallbackContext obj)
    {
        AvatarManager.Instance.SetCharacterCam();
        _input.CharacterSelection.Disable();
        _input.PlayerActions.Enable();
    }

    private void DecreaseCurrentCam_performed(InputAction.CallbackContext obj)
    {
        AvatarManager.Instance.DecreaseCurrentCam();
    }

    private void IncreaseCurrentCam_performed(InputAction.CallbackContext obj)
    {
        AvatarManager.Instance.IncreaseCurrentCam();
    }
    #endregion

    #region Movement

    private void MoveInput()
    {
        move = _input.PlayerActions.Movement.ReadValue<Vector2>();
    }

    private void LookInput()
    {
        look = _input.PlayerActions.Look.ReadValue<Vector2>();
    }

    private void Running_performed(InputAction.CallbackContext obj)
    {
        isSprinting = true;
    }

    private void Running_canceled(InputAction.CallbackContext obj)
    {
        isSprinting = false;
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        isJumping = true;
    }

    private void Jump_canceled(InputAction.CallbackContext obj)
    {
        isJumping = false;
    }

    #endregion

    #region Actions

    private void Dig_performed(InputAction.CallbackContext obj)
    {
        isDigging = true;
    }

    private void Dig_canceled(InputAction.CallbackContext obj)
    {
        isDigging = false; 
    }

    private void Bark_performed(InputAction.CallbackContext obj)
    {
        isBarking = true;
    }

    private void Bark_canceled(InputAction.CallbackContext obj)
    {
        isBarking = false;
    }

    #endregion




}
