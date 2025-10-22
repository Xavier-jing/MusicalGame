using UnityEngine;

namespace Monster
{
    public class MonsterIdleState : MonsterState
    {
        private bool playerInAttackRange;
        private bool shouldFly;
        private float idleTime;

        public MonsterIdleState(Monster monster, MonsterStateMachine stateMachine, MonsterData monsterData, string animBoolName) 
            : base(monster, stateMachine, monsterData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            // 重置速度
            monster.SetVelocityX(0);
            monster.SetVelocityY(0);
            
            // 初始化变量
            playerInAttackRange = false;
            shouldFly = false;
            idleTime = 0f;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            idleTime += Time.deltaTime;
            
            // 如果玩家在攻击范围内，切换到攻击状态
            if (playerInAttackRange)
            {
                stateMachine.ChangeState(monster.AttackState);
            }
            // 如果应该飞行或者已经在待机状态待了足够长的时间，切换到飞行状态
            else if (shouldFly || idleTime >= monsterData.idleDuration)
            {
                stateMachine.ChangeState(monster.FlyState);
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
            
            // 检查是否应该飞行
            shouldFly = CheckShouldFly();
        }

        private bool CheckPlayerInAttackRange()
        {
            // 检测玩家是否在攻击范围内
            // 临时返回false，实际实现需要根据游戏逻辑添加
            return false;
        }

        private bool CheckShouldFly()
        {
            // 检测是否应该飞行
            // 临时返回false，实际实现需要根据游戏逻辑添加
            return false;
        }
    }
}

