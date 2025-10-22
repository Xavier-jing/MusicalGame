using UnityEngine;

namespace Monster
{
    public class MonsterState
    {
        protected Monster monster;
        protected MonsterStateMachine stateMachine;
        protected MonsterData monsterData;

        protected float startTime;
        private string animBoolName;

        public MonsterState(Monster monster, MonsterStateMachine stateMachine, MonsterData monsterData, string animBoolName)
        {
            this.monster = monster;
            this.stateMachine = stateMachine;
            this.monsterData = monsterData;
            this.animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            DoChecks();
            monster.Anim.SetBool(animBoolName, true);
            startTime = Time.time;
            Debug.Log("Monster State: " + animBoolName);
        }

        public virtual void Exit()
        {
            monster.Anim.SetBool(animBoolName, false);
        }

        public virtual void LogicUpdate()
        {
            // 在子类中实现具体逻辑
        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {
            // 在子类中实现具体检测
        }
    }
}

