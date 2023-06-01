using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    #region Variables
    private float _speed;

    [SerializeField]
    private int _bonesCollected;

    private Vector2 _movement;
    private bool _playerGrounded;

    private CharacterController _controller;
    private Animator _anim;
    private float _animSpeed;
    #endregion 

    private void Start()
    {
        _anim = GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.LogError(gameObject.name + " Failed to connect the Animator");
        }

        _controller = GetComponent<CharacterController>();
        if (_controller == null)
        {
            Debug.LogError(gameObject.name + " No Character Controller Present");
        }

        _animSpeed = 0f;
    }

    #region Movement
    public void SetMovement(Vector2 move)
    {
        _movement = move;
    }
    public void SetMovementAnimation(float animSpeed)
    {
        _animSpeed = animSpeed;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void Movement()
    {
        _playerGrounded = _controller.isGrounded;
        float h = _movement.x;
        float v = _movement.y;

        transform.Rotate(transform.up, h);


        Vector3 direction = transform.forward * v;
        Vector3 velocity = direction * _speed;

        _anim.SetFloat("Speed_f", _animSpeed);

        if (_playerGrounded)
        {
            velocity.y = 0f;
        }
        if (!_playerGrounded)
        {
            velocity.y += -2000f * Time.deltaTime;
        }

        _controller.Move(velocity * Time.deltaTime);
    }
    #endregion

    private void Update()
    {
        Movement();
    }
}
