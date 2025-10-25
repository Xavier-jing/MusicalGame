using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public TextAsset monsterCSV;
    public NoteSpawner noteSpawner;
    
    private List<MonsterData> monsterDataList;
    private HashSet<int> spawnedMonsters = new HashSet<int>();
    
    private void Start()
    {
        monsterDataList = MonsterLoader.LoadCSV(monsterCSV);
    }
    
    private void Update()
    {
        CheckForMonsterSpawn();
    }

    private void CheckForMonsterSpawn()
    {
        foreach (var monsterData in monsterDataList)
        {
            if (spawnedMonsters.Contains(monsterData.monsterId)) continue;
            
            // 检查是否生成了这个怪物的第一个音符
            if (monsterData.noteIds.Count > 0)
            {
                int firstNoteId = monsterData.noteIds[0];
                NoteController firstNoteController = NoteManager.Instance.GetControllerByNoteId(firstNoteId);

                if (firstNoteController != null)
                {
                    SpawnMonster(monsterData, firstNoteController);
                    spawnedMonsters.Add(monsterData.monsterId);
                }
            }
        }
    }
    
    private void SpawnMonster(MonsterData data, NoteController bindNote)
    {
        GameObject monsterObj = Instantiate(monsterPrefab, bindNote.transform.position, Quaternion.identity);
        MonsterController monsterController = monsterObj.GetComponent<MonsterController>();
        if (monsterController == null)
        {
            monsterController = monsterObj.AddComponent<MonsterController>();
        }
        
        monsterController.Initialize(data, bindNote);
        MonsterManager.Instance.RegisterMonster(monsterController);
    }
}

