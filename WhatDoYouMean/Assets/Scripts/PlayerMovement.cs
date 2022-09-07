using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    [SerializeField] float _speed = 5;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        int x = (int)Input.GetAxisRaw("Horizontal"),
            y = (int)Input.GetAxisRaw("Vertical");

        _rb.velocity = new Vector2(x * _speed, y * _speed);
        if (_rb.velocity.magnitude > 0) _animator.Play("Move");
        else _animator.Play("None");
    }
}
