using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class NoteSpawner : MonoBehaviour
{
    public GameObject[] notePrefabs;
    public Transform[] trackPoints;
    public NoteProcessor noteProcessor;
    public List<MusicNote> allNotes;
    public float targetYOffset = 2f;
    private HashSet<int> spawnedNotes = new HashSet<int>();

    private void Start()
    {
        allNotes = noteProcessor.allNotes;
    }

    public void UpdateSpawner(float currentTime)
    {
        foreach (var note in allNotes)
        {
            if (!spawnedNotes.Contains(note.id) && currentTime >= note.appearTime)
            {
                note.spawnPos = CalculateSpawnPos(note);
                note.targetPos = CalculateTargetPos(note);
                SpawnNote(note);
                spawnedNotes.Add(note.id);
            }
        }
    }

    private void SpawnNote(MusicNote note)
    {
        GameObject prefab = GetPrefabForNote(note);

        GameObject realNote = Instantiate(prefab, note.spawnPos, Quaternion.identity);
    }

    private GameObject GetPrefabForNote(MusicNote note)
    {
        if (note.actionType == ActionType.Jump) return null;
        else if(note.iconType >= 0 && note.iconType < notePrefabs.Length)
            return notePrefabs[note.iconType];
        else return null;
    }

    private Vector2 CalculateSpawnPos(MusicNote note)
    {
        if (trackPoints == null || trackPoints.Length == 0)
            return Vector2.zero;

        if (trackPoints.Length == 1)
            return trackPoints[0].position;
        float t = 0f;
        t = Mathf.Clamp01(note.appearTime / 5f);

        int lastIndex = trackPoints.Length - 1;
        float totalSegments = lastIndex;
        float scaledT = t * totalSegments;
        int segment = Mathf.FloorToInt(scaledT);
        segment = Mathf.Clamp(segment, 0, lastIndex - 1);
        float localT = scaledT - segment;

        Vector2 start = trackPoints[segment].position;
        Vector2 end = trackPoints[segment + 1].position;

        return Vector2.Lerp(start, end, localT);
    }

    private Vector2 CalculateTargetPos(MusicNote note)
    {
        Vector2 target = note.spawnPos;
        target.y -= targetYOffset;
        return target;
    }
}

