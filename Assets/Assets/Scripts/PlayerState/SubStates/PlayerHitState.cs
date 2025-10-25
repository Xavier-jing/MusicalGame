using UnityEngine;

/// <summary>
/// 玩家打击状态（攻击命中或打击反馈）
/// 触发条件：策划定义的事件，例如按键、命中音符等
/// </summary>
public class PlayerHitState : PlayerAbilityState
{
    public PlayerHitState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
        : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // 播放打击动画
        player.Anim.Play("Hit");

        
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        AnimatorStateInfo stateInfo = player.Anim.GetCurrentAnimatorStateInfo(0);

        // 当动画播放完毕时，回到MoveState
        if (stateInfo.normalizedTime >= 1.0f)
        {
            stateMachine.ChangeState(player.MoveState);
        }
    }

    public override void Exit()
    {
        base.Exit();

      
    }
}