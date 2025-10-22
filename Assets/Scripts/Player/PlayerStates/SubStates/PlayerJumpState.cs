using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����Ծ״̬ 10.17
/// </summary>
public class PlayerJumpState : PlayerAbilityState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityY(playerData.jumpVelocity);
        isAbilityDone = true;
    }
}
