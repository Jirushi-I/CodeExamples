using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float velocity = -10f;
    
    private Vector2 _movement2D;
    private CharacterController _controller;
    private bool _jump;
    private float _velocity;
    private bool _isGrounded;
    private int _jumpDelay;
    public UnityEvent OnMove;
    public UnityEvent OnJump;
    public UnityEvent OnLand;


    private void Awake()
    {
        _isGrounded = true;
        _controller = GetComponent<CharacterController>();
    }
    
    public void Move(Vector2 vector2)
    {
        _movement2D = vector2*speed;
        OnMove?.Invoke();
    }
    
    public void Move(InputAction.CallbackContext c)
    {
        Move(c.ReadValue<Vector2>());
    }

    private void FixedUpdate()
    {

        _controller.Move(new Vector3(
                             _movement2D.x,
                             velocity,
                             _movement2D.y
                         )*Time.fixedDeltaTime);
    }

    public void Jump(float height)
    {
        if(!_isGrounded)
            return;
        OnJump?.Invoke();
        
        _isGrounded = false;
        Invoke(nameof(Land), height);
    }
    
    public void Jump(InputAction.CallbackContext c)
    {
        if(c.ReadValue<float>() >= 0.9f)
            Jump(1);
    }
    
    private void Land()
    {
        OnLand?.Invoke();
        Invoke(nameof(Land2), 0.5f);
    }
    
    private void Land2()
    {
        _isGrounded = true;
    }
}

