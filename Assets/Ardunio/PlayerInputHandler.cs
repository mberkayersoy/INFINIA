using System;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    //[Header("Input Values")]
    //public Vector2 move;
    //public bool jump;

    //PlayerInputActions playerInputActions;

    //private void Awake()
    //{
    //    playerInputActions = new PlayerInputActions();

    //    playerInputActions.Player.Enable();

    //    playerInputActions.Player.Move.performed += Move_performed;
    //    playerInputActions.Player.Move.canceled += Move_performed;
    //    playerInputActions.Player.AdditionalInput.performed += AdditionalInput_performed;

    //}

    //private void AdditionalInput_performed(InputAction.CallbackContext obj)
    //{
    //    Debug.Log("Additional Input");
    //}

    //private void Start()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //}

    //private void Move_performed(InputAction.CallbackContext callback)
    //{
    //    move = callback.ReadValue<Vector2>();
    //    //Debug.Log(callback.ReadValue<Vector2>());
    //}

    //private void OnDestroy()
    //{
    //    playerInputActions.Player.Move.performed -= Move_performed;
    //    playerInputActions.Player.Move.canceled -= Move_performed;
    //    playerInputActions.Player.AdditionalInput.performed += AdditionalInput_performed;
    //}
}
