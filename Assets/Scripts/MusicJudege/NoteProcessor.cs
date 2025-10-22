using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����������ֺ���ʧ 10.18
/// </summary>
public class NoteProcessor : MonoBehaviour
{
    public AudioSource audioSource;
    public TextAsset chartFile;
    public List<MusicNote> allNotes = new List<MusicNote>();
    [HideInInspector] 
    public List<MusicNote> activeNotes = new List<MusicNote>();

    private void Start()
    {
        LoadChartData();
    }

    private void LoadChartData()
    {
        string json = chartFile.text;
        ChartData chart = JsonUtility.FromJson<ChartData>(json);
        allNotes = chart.notes;
        Debug.Log($"Loaded chart with {allNotes.Count} notes.");
    }

    private void Update()
    {
        float currentTime = audioSource.time;

        // 1. ������δ���ֵ�����
        for (int i = 0; i < allNotes.Count; i++)
        {
            MusicNote note = allNotes[i];
            if (note.state == MushroomState.Idle && currentTime >= note.appearTime)
            {
                note.state = MushroomState.Active;
                activeNotes.Add(note);
                Debug.Log($"Note {note.id} activated at {currentTime}s");
            }
        }

        // 2. ����Ծ�����Ƿ�ʱ,�������û�в���miss
        for (int i = activeNotes.Count - 1; i >= 0; i--)
        {
            MusicNote note = activeNotes[i];
            if (!note.hasBeenJudged && currentTime > note.disappearTime)
            {
                note.state = MushroomState.Missed;
                note.hasBeenJudged = true;
                Debug.Log($"Note {note.id} MISSED at {currentTime}s");
                activeNotes.RemoveAt(i);
            }
        }
    }
}
