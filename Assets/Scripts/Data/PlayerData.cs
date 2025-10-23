  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 基本数值设置
/// </summary>

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public LayerMask whatIsGround;

    //[Header("Move State")]
    //public float movementVelocity = 5f;

    [Header("Jump State")]
    public float autoJumpCheckDistance = 1f;
    public float jumpVelocity = 6f;

    [Header("Attack Settings")]
    public float attackRadius = 10f;
    public LayerMask whatIsEnemy;

}
