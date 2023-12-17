using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystemsCookbook;
using System;

public class Player1Movement : MonoBehaviour
{
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    private float jumpTimeout = 0.5f;
    private float _jumpTimeoutDelta;

    public event Action<float> OnSpeedChangeAction;
    public event Action<bool> OnGroundStateChangeAction;
    public event Action<bool> OnJumpAction;
    public event Action<bool> OnFreeFallAction;

    private PlayerInputHandler _input;
    private GroundCheck _groundCheck;
    private Rigidbody _rb;
    private void Start()
    {
        _groundCheck.OnIsGroundedChangeAction += GroundCheck_OnIsGroundedChangeAction;
    }
    private void GroundCheck_OnIsGroundedChangeAction(bool isGrounded)
    {
        this.isGrounded = isGrounded;
        OnGroundStateChangeAction?.Invoke(isGrounded);
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerInputHandler>();
        _groundCheck = GetComponent<GroundCheck>();
    }

    void Update()
    {
        Jump();
        Move();
    }

    private void Move()
    {
        // normalise input direction
        Vector2 horizontalInput = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;
        Vector3 moveVector;
        if (horizontalInput.x > 0) {
             moveVector = transform.forward * speed;

            transform.rotation = Quaternion.LookRotation(transform.forward);
        }
        else if (horizontalInput.x < 0)
        {
            moveVector = -transform.forward * speed;
            transform.rotation = Quaternion.LookRotation(-transform.forward);
        }
        else
        {
            moveVector = Vector3.zero;
        }

        _rb.velocity = new Vector3(moveVector.x, _rb.velocity.y, moveVector.z);

        OnSpeedChangeAction?.Invoke(Mathf.Abs(_input.move.x));
    }

    private void Jump()
    {
        if (isGrounded)
        {
            OnJumpAction?.Invoke(false);
            OnFreeFallAction?.Invoke(false);

            if (_input.jump && _jumpTimeoutDelta <= 0.0f)
            {
                Debug.Log("jump");
                _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                OnJumpAction?.Invoke(true);

                _input.jump = false;
            }

            // jump timeout
            if (_jumpTimeoutDelta >= 0.0f)
            {
                _jumpTimeoutDelta -= Time.deltaTime;
            }
        }
        else
        {
            // reset the jump timeout timer
            _jumpTimeoutDelta = jumpTimeout;

            if (_rb.velocity.y <= 0f)
            {
                OnFreeFallAction?.Invoke(true);
            }

            _input.jump = false;
        }
    }
}