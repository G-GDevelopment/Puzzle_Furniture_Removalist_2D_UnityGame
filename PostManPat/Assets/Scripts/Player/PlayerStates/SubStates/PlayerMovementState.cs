using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerGroundedState
{
    public PlayerMovementState(Player p_player, PlayerStateMachine p_stateMachine, PlayerData p_playerData, string p_animboolName) : base(p_player, p_stateMachine, p_playerData, p_animboolName)
    {
    }

    public override void StandardUpdate()
    {
        base.StandardUpdate();

        core.Movement.ShouldFlip(inputX);

        core.Movement.SetVelocityX(playerData.MovementVelocity * inputX);

        if (!isExistingState)
        {
            if (inputX == 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }

        }

    }
}
