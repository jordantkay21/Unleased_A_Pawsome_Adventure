using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private GameInputActions _input;

    // Start is called before the first frame update
    void Start()
    {
        InitializeInputs();
    }

    private void Update()
    {
        SetPlayerMovement();
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

    private void SetPlayerMovement()
    {
        Vector2 move = _input.PlayerActions.Movement.ReadValue<Vector2>();
        Player.Instance.SetDirection(move);
    }
    private void Running_canceled(InputAction.CallbackContext obj)
    {
        Player.Instance.isRunning = false;
    }

    private void Running_performed(InputAction.CallbackContext obj)
    {
        Player.Instance.isRunning = true;
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        Player.Instance.IsJumping();
    }

    #endregion
}
