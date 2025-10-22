using System.Linq;
using UnityEngine;
/// <summary>
/// �����ж��߼� 10.18
/// </summary>
public class Dispatcher : MonoBehaviour
{
    public NoteProcessor processor;      
    public float earlyWindow = 0.16f;  //��ҿ�����ǰ������ʱ�䷶Χ
    public float lateWindow = 0.16f; //��ҿ�����������ʱ�䷶Χ
    public float comboWindow = 0.12f; // �ж�combo��ʱ�����

    void Start()
    {
        var inputHandler = Object.FindAnyObjectByType<RhythmUiInput>();
        inputHandler.onPressEvent.AddListener(OnPress);
    }

    void OnPress(int laneIndex)
    {
        float currentTime = processor.audioSource.time;

        // 1. ɸѡ��ǰ���ж�����
        var candidates = processor.activeNotes.Where(m => m.lane == laneIndex && !m.hasBeenJudged 
        && currentTime >= m.hitTime - earlyWindow 
        && currentTime <= m.hitTime + lateWindow).ToList();

        if (candidates.Count == 0)
        {
            Debug.Log($"Lane {laneIndex} press: no candidate -> MissClick");
            return;
        }

        // 2. ʱ�����ȣ�ѡ�� hitTime �� currentTime ����С������
        var best = candidates.OrderBy(m => Mathf.Abs(m.hitTime - currentTime)).First();
        float dt = Mathf.Abs(best.hitTime - currentTime);

        // 3. �ж� combo/miss��������Ҳ����˵����
        if (dt <= comboWindow)
        {
            best.state = MushroomState.Judged;
            best.hasBeenJudged = true;
            processor.activeNotes.Remove(best);
            Debug.Log($"Lane {laneIndex} COMBO! Note {best.id}");
        }
        else
        {
            best.state = MushroomState.Missed;
            best.hasBeenJudged = true;
            processor.activeNotes.Remove(best);
            Debug.Log($"Lane {laneIndex} LATE -> MISS Note {best.id}");
        }
    }
}
