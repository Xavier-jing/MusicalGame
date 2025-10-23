using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家静止类 10.17
/// </summary>
public class PlayerIdleState : PlayerGroundedState
{

    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocityX(0);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (IsGrounded && IsIdle())
        {
            stateMachine.ChangeState(player.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public bool IsIdle()
    {
        //看具体判定
        return true;
    }
}
