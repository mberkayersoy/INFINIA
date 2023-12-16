using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystemsCookbook;

public class ArdunioListener : MonoBehaviour
{
    [SerializeField] private Vector2EventChannelSO _ardunioInput;
    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        Vector2 vInput = Vector2.zero;
        Vector2 hInput = Vector2.zero;
        switch (msg[0])
        {
            case '1':
                vInput = new Vector2(int.Parse(msg[0].ToString()), vInput.y);
                break;
            case '2':
                vInput = new Vector2(vInput.x, int.Parse(msg[0].ToString()));
                break;
            case '3':
                hInput = new Vector2(int.Parse(msg[0].ToString()), hInput.x);
                break;
            case '4':
                hInput = new Vector2(hInput.x, int.Parse(msg[0].ToString()));
                break;
            default:
                break;
        }
        Vector2 inputVector = new Vector2(vInput.x + vInput.y, hInput.x + hInput.y).normalized;

        Debug.Log("message" + msg);
        
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
