using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int inputX;
    protected int inputY;
    protected bool isTouchingCelling;


    private bool _jumpInput;
    private bool _pickUpInput;
    private bool _flipInput;
    private bool _rotateInput;

    private bool _isGrounded;
    private bool _isTouchingWall;




    public PlayerGroundedState(Player p_player, PlayerStateMachine p_stateMachine, PlayerData p_playerData, string p_animboolName) : base(p_player, p_stateMachine, p_playerData, p_animboolName)
    {
    }

    public override void ChecksForSwitchingState()
    {
        base.ChecksForSwitchingState();

        _isGrounded = core.CollisionSenses.IsGrounded;
        _isTouchingWall = core.CollisionSenses.WallFront;
        isTouchingCelling = core.CollisionSenses.UnderCelling;
    }

    public override void EnterState()
    {
        base.EnterState();

        player.JumpState.ResetAmountOfJumpsLeft();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void StandardUpdate()
    {
        base.StandardUpdate();
        /////////////
        ///

        inputX = player.InputHandler.NormalizeInputX;
        inputY = player.InputHandler.NormalizeInputY;
        _jumpInput = player.InputHandler.JumpInput;
        _pickUpInput = player.InputHandler.PickUpInput;
        _flipInput = player.InputHandler.FlipInput;
        _rotateInput = player.InputHandler.RotateInput;

        ///
        /////////////----- Updating Input

        if (_jumpInput && player.JumpState.CanJump() && !isTouchingCelling)
        {

            stateMachine.ChangeState(player.JumpState);
        }
        else if (!_isGrounded)
        {
            player.InAirState.StartCoyoteTime();
            stateMachine.ChangeState(player.InAirState);
        }

    }
}
