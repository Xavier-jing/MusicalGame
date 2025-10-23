using System.Linq;
using UnityEngine;
/// <summary>
/// 音符判定逻辑 10.18
/// </summary>
public class Dispatcher : MonoBehaviour
{
    public NoteProcessor processor;      
    public float earlyWindow = 0.16f;  //玩家可以提前按键的时间范围
    public float lateWindow = 0.16f; //玩家可以晚按键的时间范围
    public float comboWindow = 0.12f; // 判定combo的时间误差
    public bool isCombo = false;
    [HideInInspector]
    public int comboCount = 0;

    void Start()
    {
        var inputHandler = Object.FindAnyObjectByType<RhythmUiInput>();
        inputHandler.onPressEvent.AddListener(OnPress);
    }

    void OnPress(int laneIndex)
    {
        float currentTime = processor.audioSource.time;

        // 1. 筛选当前可判定音符
        var candidates = processor.activeNotes.Where(m => m.noteType == laneIndex && !m.hasBeenJudged 
        && currentTime >= m.hitTime - earlyWindow 
        && currentTime <= m.hitTime + lateWindow).ToList();

        if (candidates.Count == 0)
        {
            Debug.Log($"Lane {laneIndex} press: no candidate -> MissClick");
            return;
        }

        // 2. 时间优先，选择 hitTime 与 currentTime 差最小的音符
        MusicNote best = candidates.OrderBy(m => Mathf.Abs(m.hitTime - currentTime)).First();
        float dt = Mathf.Abs(best.hitTime - currentTime);

        // 3. 判定combo/miss，处理玩家操作了的情况
        if (dt <= comboWindow)
        {
            isCombo = true;
            best.state = NoteState.Judged;
            best.hasBeenJudged = true;
            processor.activeNotes.Remove(best);
            comboCount++;
            Debug.Log($"Lane {laneIndex} COMBO! Note {best.id}");
        }
        else
        {
            best.state = NoteState.Missed;
            best.hasBeenJudged = true;
            processor.activeNotes.Remove(best);
            Debug.Log($"Lane {laneIndex} LATE -> MISS Note {best.id}");
        }
    }
}
