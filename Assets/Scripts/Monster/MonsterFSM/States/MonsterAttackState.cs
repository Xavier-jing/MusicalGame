using UnityEngine;

namespace Monster
{
    public class MonsterAttackState : MonsterState
    {
        private bool isAttackFinished;
        private bool playerInAttackRange;
        private float attackTimer;

        public MonsterAttackState(Monster monster, MonsterStateMachine stateMachine, MonsterData monsterData, string animBoolName) 
            : base(monster, stateMachine, monsterData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            isAttackFinished = false;
            attackTimer = 0f;
            
            // 停止移动
            monster.SetVelocityX(0);
            monster.SetVelocityY(0);
            
            // 执行攻击动作
            PerformAttack();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            attackTimer += Time.deltaTime;
            
            // 检查攻击是否完成
            if (attackTimer >= monsterData.attackDuration)
            {
                isAttackFinished = true;
            }
            
            // 如果攻击完成，根据玩家位置决定下一个状态
            if (isAttackFinished)
            {
                if (playerInAttackRange && monsterData.canComboAttack)
                {
                    // 如果玩家还在攻击范围内并且可以连击，则再次攻击
                    stateMachine.ChangeState(monster.AttackState);
                }
                else
                {
                    // 否则回到待机状态
                    stateMachine.ChangeState(monster.IdleState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void DoChecks()
        {
            base.DoChecks();
            
            // 检查玩家是否在攻击范围内
            playerInAttackRange = CheckPlayerInAttackRange();
        }

        private void PerformAttack()
        {
            // 执行攻击逻辑
            // 如检测玩家是否在攻击范围内，造成伤害等
            Debug.Log("Monster is attacking!");
        }

        private bool CheckPlayerInAttackRange()
        {
            // 检测玩家是否在攻击范围内
            // 临时返回false，实际实现需要根据游戏逻辑添加
            return false;
        }
    }
}

