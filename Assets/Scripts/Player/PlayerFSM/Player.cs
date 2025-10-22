using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Íæ¼Ò¿ØÖÆ 10.17
/// </summary>
public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }

    public PlayerJumpState JumpState { get; private set; }

    public PlayerInAirState InAirState { get; private set; }

    public PlayerAttack1State Attack1State { get; private set; }

    public PlayerAttack2State Attack2State { get; private set; }

    public PlayerAttack3State Attack3State { get; private set; }

    public PlayerShieldState ShieldState { get; private set; }

    public IDamageable iDamageable {  get; private set; }

    [SerializeField]
    private PlayerData playerData;

    #endregion

    #region Components
    public Animator Anim { get; private set; }

    public Rigidbody2D RB { get; private set; }

    public BoxCollider2D Collider2D { get; private set; }

    public Vector2 CurrentVelocity { get; private set; }
    #endregion

    #region check Transforms
    [SerializeField]
    private Transform groundcheck;
    #endregion

    #region other variables
    public int FacingDirection { get; private set; }

    private Vector2 workspace;

    public float gravityScale { get; private set; }
    #endregion

    #region Callback Functions
    public void Awake()
    {
        stateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, stateMachine,playerData, "idle");

        MoveState = new PlayerMoveState(this, stateMachine, playerData, "move");

        JumpState = new PlayerJumpState(this, stateMachine, playerData, "inair");

        InAirState = new PlayerInAirState(this, stateMachine, playerData, "inair");

        Attack1State = new PlayerAttack1State(this, stateMachine, playerData, "attack1");

        Attack2State = new PlayerAttack2State(this, stateMachine, playerData, "attack2");

        Attack3State = new PlayerAttack3State(this, stateMachine, playerData, "attack3");

        ShieldState = new PlayerShieldState(this, stateMachine, playerData, "shield");
    }
    
    private void Start()
    {
        Anim = GetComponent<Animator>();

        stateMachine.Initialize(IdleState);

        RB = GetComponent<Rigidbody2D>();

        Collider2D = GetComponent<BoxCollider2D>();

        gravityScale = RB.gravityScale;

        FacingDirection = 1;
    }

    private void Update()   
    {
        CurrentVelocity = RB.linearVelocity;
        stateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
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

    #region Check Functions
    public bool CheckIfTouchingGround()
    {
        return Physics2D.OverlapCircle(groundcheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
    }

    #endregion

}
