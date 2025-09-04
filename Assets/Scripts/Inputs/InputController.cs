using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public InputData inputData;
    private InputSystem_Actions actions;


    private void Awake()
    {
        if (actions == null)
            actions = new InputSystem_Actions();
        
        actions.Enable();
        
        actions.Player.Move.performed += OnMove;
        actions.Player.Move.canceled += OnMove;
    }

    private void OnDestroy()
    {
        
        actions.Disable();
        
        actions.Player.Move.performed -= OnMove;
        actions.Player.Move.canceled -= OnMove;
    }

    private void OnMove(InputAction.CallbackContext moveValue)
    {
        Vector2 moveInput = moveValue.ReadValue<Vector2>();
        inputData.moveInputData = moveInput;
    }
}