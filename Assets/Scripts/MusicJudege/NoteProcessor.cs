using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����������ֺ���ʧ 10.18
/// </summary>
public class NoteProcessor : MonoBehaviour
{
    public AudioSource audioSource;
    public TextAsset chartFile;
    public float bpm = 100f;
    public List<MusicNote> allNotes = new List<MusicNote>();
    [HideInInspector] 
    public List<MusicNote> activeNotes = new List<MusicNote>();

    private void Awake()
    {
        allNotes = NoteLoader.LoadCSV(chartFile, bpm);
    }

    public void ProcessNote()
    {
        float currentTime = audioSource.time;

        // 1. ������δ���ֵ�����
        for (int i = 0; i < allNotes.Count; i++)
        {
            MusicNote note = allNotes[i];
            if (note.state == NoteState.Idle && currentTime >= note.appearTime)
            {
                note.state = NoteState.Active;
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
                note.state = NoteState.Missed;
                note.hasBeenJudged = true;
                Debug.Log($"Note {note.id} MISSED at {currentTime}s");
                activeNotes.RemoveAt(i);
            }
        }
    }
}
