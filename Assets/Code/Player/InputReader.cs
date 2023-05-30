using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private Vector2 moveInput;
    private bool jumpInput;
   
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpInput = true;
        }
        if (context.canceled)
        {
            jumpInput = false;
        }
    }
    public Vector2 GetMoveInput() { return moveInput; }
    public bool GetJumpInput() { return jumpInput; }
}
