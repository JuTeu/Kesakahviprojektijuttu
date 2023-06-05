using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private Vector2 moveInput;
    private bool jumpInput;
    private bool action2;
   
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
    public void OnAction2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            action2 = true;
        }
        if (context.canceled)
        {
            action2 = false;
        }
    }
    public Vector2 GetMoveInput() { return moveInput; }
    public bool GetJumpInput() { return jumpInput; }
    public bool GetAction2Input() { return action2; }
}
