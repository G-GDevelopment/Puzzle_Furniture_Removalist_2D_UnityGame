using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    //Input
    private int _inputX;
    private bool _grabInput;

    private bool _jumpInput;
    private bool _jumpInputStop;

    private bool _dashInput;

    private bool _changeAbilityInput;
    private bool _abilityInput;

    //Checks
    private bool _isGrounded;

    private bool _isTouchingLedge;
    private bool _isTouchingWall;
    private bool _isTouchingBackWall;

    private bool _oldIsTouchingWall;
    private bool _oldIsTouchingBackWall;

    //Time Variables
    private bool _coyoteTime;
    private bool _isJumping;


    public PlayerInAirState(Player p_player, PlayerStateMachine p_stateMachine, PlayerData p_playerData, string p_animboolName) : base(p_player, p_stateMachine, p_playerData, p_animboolName)
    {
    }

    public override void ChecksForSwitchingState()
    {
        base.ChecksForSwitchingState();

        _oldIsTouchingWall = _isTouchingWall;
        _oldIsTouchingBackWall = _isTouchingBackWall;

        _isGrounded = core.CollisionSenses.IsGrounded;
        _isTouchingWall = core.CollisionSenses.WallFront;
        _isTouchingBackWall = core.CollisionSenses.WallBack;
    }

    public override void EnterState()
    {
        base.EnterState();

    }

    public override void ExitState()
    {
        base.ExitState();

        _oldIsTouchingWall = false;
        _oldIsTouchingBackWall = false;

        _isTouchingWall = false;
        _isTouchingBackWall = false;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        JumpMultiplier();
        core.Movement.SmoothFalling(playerData.FallMultiplier, playerData.LowJumpMultiplier, player.InputHandler.JumpInput);
    }

    public override void StandardUpdate()
    {
        base.StandardUpdate();

        CheckCoyoteTime();

        _jumpInput = player.InputHandler.JumpInput;
        _jumpInputStop = player.InputHandler.JumpInputStop;


        _inputX = player.InputHandler.NormalizeInputX;

        Debug.Log(_isTouchingWall);
        Debug.Log(_inputX + " == " + core.Movement.FacingDirection);
        Debug.Log(core.Movement.CurrentVelocity.y + " < 0 ?");

        if (_isGrounded && core.Movement.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        else if (_jumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (_isTouchingWall && _inputX == core.Movement.FacingDirection)
        {
            stateMachine.ChangeState(player.WallSlideSlide);
        }
        else
        {
            core.Movement.ShouldFlip(_inputX);
            core.Movement.SetVelocityX(playerData.MovementVelocity * _inputX);

            player.Animator.SetFloat("YVelocity", core.Movement.CurrentVelocity.y);
            player.Animator.SetFloat("XVelocity", Mathf.Abs(core.Movement.CurrentVelocity.x));
        }
    }

    private void CheckCoyoteTime()
    {
        if (_coyoteTime && Time.time > startTime + playerData.CoyoteTime)
        {
            _coyoteTime = false;
            player.JumpState.DecreaseAmountOfJumpsLeft();
        }
    }

    private void JumpMultiplier()
    {
        if (_isJumping)
        {
            if (_jumpInputStop)
            {
                core.Movement.SetVelocityY(core.Movement.CurrentVelocity.y * playerData.VariableJumpHeightMultiplier);
                _isJumping = false;
            }
            else if (core.Movement.CurrentVelocity.y <= 0f)
            {
                _isJumping = false;
            }
        }
    }
    public void StartCoyoteTime() => _coyoteTime = true;
    public void SetIsJumping() => _isJumping = true;
}
