using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float strafeSpeed;
    public float jumpForce;

    public Rigidbody torso;
    public bool isGrounded;
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            torso.AddForce(new Vector3(0,0, speed));
            Debug.Log("W");
        }
    }
}
