using UnityEngine;
/// <summary>
/// 第三种攻击方式 10.17
/// </summary>
public class PlayerAttack3State : PlayerAttackState
{
    public PlayerAttack3State(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DealDamage()
    {
        base.DealDamage();
        /*具体攻击范围写这里
        */
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}