using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterData
{
    public int monsterId;
    public List<int> noteIds;
    public MonsterType monsterType;
    public int health;
    
    public MonsterData()
    {
        noteIds = new List<int>();
    }
}

public class MonsterLoader
{
    public static List<MonsterData> LoadCSV(TextAsset csv)
    {
        List<MonsterData> monsters = new List<MonsterData>();
        string[] lines = csv.text.Split('\n');
        bool isFirst = true;
        
        foreach (string line in lines)
        {
            string line1 = line.Trim();
            if (string.IsNullOrEmpty(line1)) continue;
            if (isFirst) { isFirst = false; continue; }
            
            string[] parts = line1.Split(',');
            MonsterData monster = new MonsterData
            {
                monsterId = int.Parse(parts[0]),
                monsterType =  (MonsterType)System.Enum.Parse(typeof(MonsterType), parts[1]),
                //health = int.Parse(parts[2])
            };
            
            // 从第3列开始是音符ID列表
            for (int i = 2; i < parts.Length; i++)
            {
                if (!string.IsNullOrEmpty(parts[i]) && int.TryParse(parts[i], out int noteId))
                {
                    monster.noteIds.Add(noteId);
                }
            }
            
            monsters.Add(monster);
        }
        
        return monsters;
    }
}

public enum MonsterType
{
    ChirpingInsect
}


