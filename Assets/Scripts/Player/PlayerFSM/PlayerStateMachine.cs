using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���״̬��������
/// ���𱣴棬��ʼ�����ı�״̬ 10.17
/// </summary>
public class PlayerStateMachine
{
    //���浱ǰ״̬
    public PlayerState currentState { get; private set; }

    //��ʼ״̬
    public void Initialize(PlayerState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    //�ı�״̬
    public void ChangeState(PlayerState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
