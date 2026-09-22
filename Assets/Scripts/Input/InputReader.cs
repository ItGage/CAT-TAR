using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    private Controls controls;

    public Action JumpPerformed;
    public Action MoveLeftPerformed;
    public Action MoveRightPerformed;
    public Action ParryPerformed;

    public Action UpPerformed;
    public Action LeftPerformed;
    public Action RightPerformed;
    public Action DownPerformed;

    private void OnEnable()
    {
        if(controls == null)
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this);
            controls.Player.Enable();
        }
    }

    private void OnDisable()
    {
        if(controls != null)
        {
            controls.Player.Disable();
        }
    }

    #region Actions

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            JumpPerformed?.Invoke();
        }
    }

    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MoveLeftPerformed?.Invoke();
        }
    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MoveRightPerformed?.Invoke();
        }
    }

    public void OnParry(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ParryPerformed?.Invoke();
        }
    }

    public void OnUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            UpPerformed?.Invoke();
        }
    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            LeftPerformed?.Invoke();
        }
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RightPerformed?.Invoke();
        }
    }

    public void OnDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DownPerformed?.Invoke();
        }
    }

    #endregion
}
