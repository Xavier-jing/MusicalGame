using UnityEngine;

    /// <summary>
    /// 玩家采集状态（用于采集）
    /// </summary>
    public class PlayerGatherState : PlayerAbilityState
    {
        public PlayerGatherState(Player player, PlayerStateMachine stateMachine, PlayerData playerData,
            string animBoolName)
            : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            // 播放采集动画
            player.Anim.Play("Gather");



        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            AnimatorStateInfo stateInfo = player.Anim.GetCurrentAnimatorStateInfo(0);

            // 动画播放完毕后，执行采集结果逻辑
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
