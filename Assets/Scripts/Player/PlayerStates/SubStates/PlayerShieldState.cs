using UnityEngine;
/// <summary>
/// ����׶�״̬ 10.17
/// ��״̬���������Ȳ߻�����Ȼ����PlayerGroundedState / PlayerMoveState / PlayerAbilityState�����л�
/// </summary>
public class PlayerShieldState : PlayerAbilityState
{
    public PlayerShieldState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
}
