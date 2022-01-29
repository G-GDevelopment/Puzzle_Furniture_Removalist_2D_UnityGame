using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchingWallState : PlayerState
{

    protected bool isGrounded;
    protected bool isTouchingWall;
    protected bool jumpInput;

    protected int inputX;
    protected int inputY;
    public PlayerTouchingWallState(Player p_player, PlayerStateMachine p_stateMachine, PlayerData p_playerData, string p_animboolName) : base(p_player, p_stateMachine, p_playerData, p_animboolName)
    {
    }

    public override void ChecksForSwitchingState()
    {
        base.ChecksForSwitchingState();

        isGrounded = core.CollisionSenses.IsGrounded;
        isTouchingWall = core.CollisionSenses.WallFront;
    }

    public override void StandardUpdate()
    {
        base.StandardUpdate();

        inputX = player.InputHandler.NormalizeInputX;
        inputY = player.InputHandler.NormalizeInputY;
        jumpInput = player.InputHandler.JumpInput;

        if (isGrounded)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if (!isTouchingWall || (inputX != core.Movement.FacingDirection))
        {
            stateMachine.ChangeState(player.InAirState);
        }
    }
}
