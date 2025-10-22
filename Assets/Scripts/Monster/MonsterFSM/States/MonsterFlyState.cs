using UnityEngine;

namespace Monster
{
    public class MonsterFlyState : MonsterState
    {
        private Vector2 flyDirection;
        private bool shouldLand;
        private bool playerInAttackRange;
        private float flyTimer;

        public MonsterFlyState(Monster monster, MonsterStateMachine stateMachine, MonsterData monsterData, string animBoolName) 
            : base(monster, stateMachine, monsterData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            shouldLand = false;
            flyTimer = 0f;
            
            // 设置初始飞行方向
            DetermineFlyDirection();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            flyTimer += Time.deltaTime;
            
            // 更新飞行逻辑
            UpdateFlyMovement();
            
            // 判断是否应该降落或攻击
            if (shouldLand || flyTimer >= monsterData.maxFlyDuration)
            {
                stateMachine.ChangeState(monster.IdleState);
            }
            else if (playerInAttackRange)
            {
                stateMachine.ChangeState(monster.AttackState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void DoChecks()
        {
            base.DoChecks();
            
            // 检查是否应该降落
            shouldLand = CheckShouldLand();
            
            // 检查玩家是否在攻击范围内
            playerInAttackRange = CheckPlayerInAttackRange();
        }

        private void DetermineFlyDirection()
        {
            // 设置飞行方向，可以根据玩家位置或随机方向
            flyDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f)).normalized;
        }

        private void UpdateFlyMovement()
        {
            // 根据飞行方向更新怪物速度
            monster.SetVelocityX(flyDirection.x * monsterData.flySpeed);
            monster.SetVelocityY(flyDirection.y * monsterData.flySpeed);
            
            // 每隔一段时间可以改变飞行方向
            if (Random.Range(0f, 1f) < monsterData.directionChangeProbability * Time.deltaTime)
            {
                DetermineFlyDirection();
            }
        }

        private bool CheckShouldLand()
        {
            // 检测是否应该降落
            // 临时返回false，实际实现需要根据游戏逻辑添加
            return false;
        }

        private bool CheckPlayerInAttackRange()
        {
            // 检测玩家是否在攻击范围内
            // 临时返回false，实际实现需要根据游戏逻辑添加
            return false;
        }
    }
}

