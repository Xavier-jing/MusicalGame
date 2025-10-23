using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Òô·û´ò»÷ÊäÈë°ó¶¨ 10.18
/// </summary>
public class RhythmUiInput : MonoBehaviour
{
    public UnityEvent<int> onPressEvent; // 0=×ó, 1=ÓÒ

    public void OnLeftButton()
    {
        onPressEvent?.Invoke(0);
    }

    public void OnRightButton()
    {
        onPressEvent?.Invoke(1);
    }
}
