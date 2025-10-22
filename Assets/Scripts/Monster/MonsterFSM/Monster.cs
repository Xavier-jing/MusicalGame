using UnityEngine;

namespace Monster
{
    public class Monster : MonoBehaviour
    {
        
        
        #region State Variables
        public MonsterStateMachine StateMachine { get; private set; }

        public MonsterIdleState IdleState { get; private set; }
        public MonsterAttackState AttackState { get; private set; }
        public MonsterFlyState FlyState { get; private set; }

        [SerializeField]
        private MonsterData monsterData;
        #endregion

        #region Components
        public Animator Anim { get; private set; }
        public Rigidbody2D RB { get; private set; }
        public Collider2D Collider2D { get; private set; }
        public Vector2 CurrentVelocity { get; private set; }
        #endregion

        #region Other Variables
        public int FacingDirection { get; private set; }
        private Vector2 workspace;
        #endregion

        #region Callback Functions
        private void Awake()
        {
            StateMachine = new MonsterStateMachine();

            IdleState = new MonsterIdleState(this, StateMachine, monsterData, "Idle");
            AttackState = new MonsterAttackState(this, StateMachine, monsterData, "Attack");
            FlyState = new MonsterFlyState(this, StateMachine, monsterData, "Fly");
        }

        private void Start()
        {
            Anim = GetComponent<Animator>();
            RB = GetComponent<Rigidbody2D>();
            Collider2D = GetComponent<Collider2D>();
            FacingDirection = 1;

            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            CurrentVelocity = RB.linearVelocity;
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }
        #endregion

        #region Set Functions
        public void SetVelocityX(float velocity)
        {
            workspace.Set(velocity, CurrentVelocity.y);
            RB.linearVelocity = workspace;
            CurrentVelocity = workspace;
        }

        public void SetVelocityY(float velocity)
        {
            workspace.Set(CurrentVelocity.x, velocity);
            RB.linearVelocity = workspace;
            CurrentVelocity = workspace;
        }
        #endregion
    }
}
