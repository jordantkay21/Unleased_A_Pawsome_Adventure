using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private GameInputActions _input;

    [SerializeField]
    private float _walkingSpeed;
    [SerializeField]
    private float _runningSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _input = new GameInputActions();
        _input.Dog.Enable();
        _input.Dog.Movement.performed += Movement_performed;
        _input.Dog.Movement.canceled += Movement_canceled;
        _input.Dog.Running.performed += Running_performed;
        _input.Dog.Running.canceled += Running_canceled;
    }

    private void Running_canceled(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void Running_performed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void Movement_canceled(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void Movement_performed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
