using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystemsCookbook;

public class ArdunioListener : MonoBehaviour
{
    [Header("Input Values")]
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

        //move = Vector2.zero;
        //jump = false;
        //Vector2 inputVector = new Vector2(vInput.x + vInput.y, hInput.x + hInput.y).normalized;

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
