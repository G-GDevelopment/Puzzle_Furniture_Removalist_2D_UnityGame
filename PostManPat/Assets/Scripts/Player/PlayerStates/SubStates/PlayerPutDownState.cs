using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPutDownState : PlayerAbilityState
{
    public PlayerPutDownState(Player p_player, PlayerStateMachine p_stateMachine, PlayerData p_playerData, string p_animboolName) : base(p_player, p_stateMachine, p_playerData, p_animboolName)
    {
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void ChecksForSwitchingState()
    {
        base.ChecksForSwitchingState();
    }

    public override void EnterState()
    {
        base.EnterState();

        player.InputHandler.SetPutDownToFalse();
        core.Ability.RemoveObjects();

        core.Ability.PutDownAbility(core.CollisionSenses.HandsRaycast());

        isAbilityDone = true;
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
    }
}
