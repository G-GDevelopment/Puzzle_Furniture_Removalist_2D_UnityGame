using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public int NormalizeInputX { get; private set; }
    public int NormalizeInputY { get; private set; }

    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }

    public bool PickUpInput { get; private set; }
    public bool RotateInput { get; private set; }
    public bool FlipInput { get; private set; }


    [SerializeField] private float _inputHoldTime = 0.2f;
    private float _jumpInputStartTime;

    private void Update()
    {
        CheckJumpInputHoldTime();
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormalizeInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormalizeInputY = Mathf.RoundToInt(RawMovementInput.y);

    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            _jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void OnPickUpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PickUpInput = true;
        }

        if (context.canceled)
        {
            PickUpInput = false;
        }
    }
    public void OnFlipInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            FlipInput = true;
        }

        if (context.canceled)
        {
            FlipInput = false;
        }
    }

    public void OnRotateInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RotateInput = true;
        }

        if (context.canceled)
        {
            RotateInput = false;
        }
    }
    public void SetJumpInputToFalse() => JumpInput = false;
    public void SetFlipInputToFalse() => FlipInput = false;


    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= _jumpInputStartTime + _inputHoldTime)
        {
            JumpInput = false;
        }
    }
}
