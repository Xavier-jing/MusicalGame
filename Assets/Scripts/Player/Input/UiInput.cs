using UnityEngine;

public class UiInput : MonoBehaviour
{
    public Player player; // 拖 Player 对象进来

    public void OnJumpButton()
    {
        if (player.stateMachine.currentState is PlayerGroundedState grounded)
        {
            grounded.TriggerJump();
        }
    }

    public void OnAttack1Button()
    {
        if (player.stateMachine.currentState is PlayerGroundedState grounded)
            grounded.IsAttack1();
    }

    public void OnAttack2Button()
    {
        if (player.stateMachine.currentState is PlayerGroundedState grounded)
            grounded.IsAttack2();
    }

    public void OnAttack3Button()
    {
        if (player.stateMachine.currentState is PlayerGroundedState grounded)
            grounded.IsAttack3();
    }

    public void OnShieldButton()
    {
        if (player.stateMachine.currentState is PlayerGroundedState grounded)
            grounded.IsShield();
    }
}
