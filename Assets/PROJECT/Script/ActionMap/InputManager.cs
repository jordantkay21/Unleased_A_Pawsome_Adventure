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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeInputs()
    {
        _input = new GameInputActions();
        _input.CharacterSelection.Enable();

        _input.CharacterSelection.IncreaseCurrentCam.performed += IncreaseCurrentCam_performed;
        _input.CharacterSelection.DecreaseCurrentCam.performed += DecreaseCurrentCam_performed;
        _input.CharacterSelection.ChooseCharacter.performed += ChooseCharacter_performed;
        
    }

    #region Character Selection Actions
    private void ChooseCharacter_performed(InputAction.CallbackContext obj)
    {
        AvatarManager.Instance.SetCharacterCam();
        _input.CharacterSelection.Disable();
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

}
