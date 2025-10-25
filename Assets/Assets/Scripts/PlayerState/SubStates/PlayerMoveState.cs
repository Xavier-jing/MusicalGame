using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Íæ¼ÒÅÜ²½Àà 10.17
/// </summary>
public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (ShouldAutoJump())
        {
            TriggerJump();
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private bool ShouldAutoJump()
    {
        Vector2 basePos = player.transform.position;
        Vector2 direction = Vector2.right;
        float distance = playerData.autoJumpCheckDistance;
        Vector2[] offsets = { Vector2.up * 1f, Vector2.zero, Vector2.down * 1f };

        foreach (var offset in offsets)
        {
            Vector2 origin = basePos + offset;
            RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, playerData.whatIsGround);
            Debug.DrawRay(origin, direction * distance, hit.collider ? Color.green : Color.red);
            if (hit.collider != null) 
                return true;
        }

        return false;
    }
}