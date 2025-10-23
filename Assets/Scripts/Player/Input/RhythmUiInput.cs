using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// ������������ 10.18
/// </summary>
public class RhythmUiInput : MonoBehaviour
{
    public UnityEvent<int> onPressEvent; // 0=��, 1=��

    public void OnLeftButton()
    {
        onPressEvent?.Invoke(0);
    }

    public void OnRightButton()
    {
        onPressEvent?.Invoke(1);
    }
}
