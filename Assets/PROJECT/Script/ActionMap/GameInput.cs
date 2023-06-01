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
        Player.Instance.SetMovementAnimation(.85f);
        Player.Instance.SetSpeed(_walkingSpeed);
    }

    private void Running_performed(InputAction.CallbackContext obj)
    {
        Player.Instance.SetMovementAnimation(.9f);
        Player.Instance.SetSpeed(_runningSpeed);
    }

    private void Movement_canceled(InputAction.CallbackContext obj)
    {
        Player.Instance.SetMovementAnimation(0f);
    }

    private void Movement_performed(InputAction.CallbackContext obj)
    {
        Player.Instance.SetMovementAnimation(.85f);
        Player.Instance.SetSpeed(_walkingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputs();
    }

    private void PlayerInputs()
    {
        Vector2 move = _input.Dog.Movement.ReadValue<Vector2>();
        Player.Instance.SetMovement(move);
    }
}
