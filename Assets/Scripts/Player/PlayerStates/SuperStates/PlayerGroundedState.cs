using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 负责落地状态（move,idle）10.17
/// </summary>

public class PlayerGroundedState : PlayerState
{
    protected bool IsGrounded;
    protected bool jumpTrigger;
    protected bool isAttack1;
    protected bool isAttack2;
    protected bool isAttack3;
    protected bool isShield;
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        IsGrounded = player.CheckIfTouchingGround();
    }

    public override void Enter()
    {
        base.Enter();
        jumpTrigger = false;
        isAttack1 = false;
        isAttack2 = false;
        isAttack3 = false;
        isShield = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!IsGrounded)
        {
            stateMachine.ChangeState(player.InAirState);
            return;
        }
        if (jumpTrigger)
        {
            stateMachine.ChangeState(player.JumpState);
        }else if (isAttack1)
        {
            stateMachine.ChangeState(player.Attack1State);
        }else if(isAttack2)
        {
            stateMachine.ChangeState(player.Attack2State);
        }else if (isAttack3)
        {
            stateMachine.ChangeState(player.Attack3State);
        }else if (isShield)
        {
            stateMachine.ChangeState(player.ShieldState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    #region 触发接口 留给子类用
    public void TriggerJump() => jumpTrigger = true;
    public void IsAttack1() => isAttack1 = true;
    public void IsAttack2() => isAttack2 = true;
    public void IsAttack3() => isAttack3 = true;
    public void IsShield() => isShield = true;
    #endregion
}
