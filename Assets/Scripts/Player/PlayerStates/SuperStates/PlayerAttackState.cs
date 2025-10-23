using UnityEngine;
/// <summary>
/// �������еĹ���״̬�����Ź�������������˺����ص�move��10.17
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
        //��ʱ����ʱ���������ж������ڿ��Կ��Ƕ����¼�
        attackTime += Time.deltaTime;
        if(!isAttack && attackTime >= 0.2f)
        {
            isAttack = true;
        }

        //����������תmove
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
    //    //û��Ҫ�����˼�⣬��������Чֱ�ӿ۵���Ѫ������
    //}
}


