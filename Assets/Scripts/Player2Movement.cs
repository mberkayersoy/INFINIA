using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour, IPlayer
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

    private GroundCheck _groundCheck;
    private Rigidbody _rb;
    void Start()
    {
        _jumpTimeoutDelta = jumpTimeout;
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
        _groundCheck = GetComponent<GroundCheck>();
    }

    void Update()
    {
        Jump();
        Move();
        //if ()
    }

    private void Move()
    {
        //move = Vector2.zero;
        // normalise input direction
        Vector2 horizontalInput = new Vector3(move.x, 0.0f, move.y).normalized;
        Vector3 moveVector;
        if (horizontalInput.x > 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
            moveVector = transform.forward * speed;
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(-Vector3.forward);
            moveVector = transform.forward * speed;

        }


        _rb.velocity = new Vector3(0f, _rb.velocity.y, move.x * speed);
        Debug.Log(move.x);
        OnSpeedChangeAction?.Invoke(Mathf.Abs(move.x));
    }

    private void Jump()
    {
        if (isGrounded)
        {
            OnJumpAction?.Invoke(false);
            OnFreeFallAction?.Invoke(false);

            if (jump && _jumpTimeoutDelta <= 0.0f)
            {
                Debug.Log("jump");
                _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                OnJumpAction?.Invoke(true);

                jump = false;
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

            jump = false;
        }
    }

    public Vector2 move;
    public bool jump;
    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        switch (msg[0])
        {
            case '1':
                move.y = 1;
                jump = true;
                break;
            case '2':
                move.x = -1;
                break;
            case '3':
                // Debug.Log("3 pressed: " + msg[1]);
                break;
            case '4':
                move.x = 1;
                break;
            default:
                break;
        }
        //Debug.Log("message: " + msg);

    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}