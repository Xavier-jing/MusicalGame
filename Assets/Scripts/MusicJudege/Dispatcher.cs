using System.Linq;
using UnityEngine;
/// <summary>
/// 音符判定逻辑 10.18
/// </summary>
public class Dispatcher : MonoBehaviour
{
    public RhythmUiInput inputHandler;
    public NoteProcessor processor;      
    public float earlyWindow = 0.5f;  //玩家可以提前按键的时间范围
    public float lateWindow = 5f; //玩家可以晚按键的时间范围
    public float comboWindow = 5f; // 判定combo的时间误差
    public bool isCombo = false;
    [HideInInspector]
    public int comboCount = 0;

    void Start()
    {
        if (!inputHandler) {
            inputHandler = Object.FindAnyObjectByType<RhythmUiInput>();
        }
        
        inputHandler.onPressEvent.AddListener(OnPress);
    }

    void OnPress(int laneIndex)
    {
        float currentTime = processor.audioSource.time;

        // 1. 筛选当前可判定音符
        // var candidates = processor.activeNotes.Where(m => m.noteType == laneIndex && !m.hasBeenJudged 
        //                                                                           && currentTime >= m.hitTime - earlyWindow 
        //                                                                           && currentTime <= m.hitTime + lateWindow).ToList();

        var candidates = processor.activeNotes.Where(m => m.noteType == laneIndex).ToList();

    
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

            NoteController noteController = NoteManager.Instance.GetControllerByNoteId(best.id);
            noteController.BeHit();//触发被打击函数
            
            // 广播音符被击打事件
            NoteManager.Instance.BroadcastNoteHit(best.id);
            
            Debug.LogWarning($"Lane {laneIndex} COMBO! Note {best.id}");
        }
        else//没打中
        {
            best.state = NoteState.Missed;
            best.hasBeenJudged = true;
            processor.activeNotes.Remove(best);
            Debug.Log($"Lane {laneIndex} LATE -> MISS Note {best.id}");
        }
    }
}
