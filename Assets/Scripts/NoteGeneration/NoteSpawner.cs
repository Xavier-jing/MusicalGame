using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class NoteSpawner : MonoBehaviour
{
    public GameObject[] notePrefabs;
    public NoteProcessor noteProcessor;

    public Transform player;           
    public float spawnOffsetX = 5f;    
    public float targetOffsetX = 0f;  
    public float targetOffsetY = 0f;

    public List<MusicNote> allNotes;
    private HashSet<int> spawnedNotes = new HashSet<int>();

    public float moveSpeed = 5f;

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

        NoteMover mover = realNote.GetComponent<NoteMover>(); 

        mover.Initialize(note.targetPos, moveSpeed);
    }

    private GameObject GetPrefabForNote(MusicNote note)
    {
        if (note.actionType == ActionType.Jump) return null;
        else if(note.iconType >= 0 && note.iconType < notePrefabs.Length)
            return notePrefabs[note.iconType];
        else return null;
    }

    //直接在玩家位置前生成
    private Vector2 CalculateSpawnPos(MusicNote note)
    {
        return new Vector2(player.position.x + spawnOffsetX, player.position.y); 
    }

    private Vector2 CalculateTargetPos(MusicNote note)
    {
        return new Vector2(player.position.x + targetOffsetX, player.position.y + targetOffsetY);
    }
}

