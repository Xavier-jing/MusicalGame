using UnityEngine;
/// <summary>
/// 处理所有的攻击状态（播放攻击动画，造成伤害，回到move）10.17
/// </summary>
public class PlayerAttackState : PlayerState
{
    protected float attackTime;
    protected bool isAttack;

    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        attackTime = 0;
        isAttack = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //暂时先用时间做攻击判定，后期可以考虑动画事件
        attackTime += Time.deltaTime;
        if(!isAttack && attackTime >= 0.2f)
        {
            isAttack = true;
        }

        //动画结束跳转move
        AnimatorStateInfo stateInfo = player.Anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1.0f)
        {
            stateMachine.ChangeState(player.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    //public virtual void DealDamage()
    //{
    //    //没必要做敌人检测，播放完特效直接扣敌人血量就行
    //}
}


