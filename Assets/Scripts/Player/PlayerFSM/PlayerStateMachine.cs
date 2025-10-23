using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家状态机核心类
/// 负责保存，初始化，改变状态 10.17
/// </summary>
public class PlayerStateMachine
{
    //保存当前状态
    public PlayerState currentState { get; private set; }

    //起始状态
    public void Initialize(PlayerState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    //改变状态
    public void ChangeState(PlayerState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
