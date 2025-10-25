using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;
    
    private List<MonsterController> activeMonsters = new List<MonsterController>();

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            // 监听音符被击打事件
            NoteManager.Instance.OnNoteHit.AddListener(OnNoteHit);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void RegisterMonster(MonsterController monster)
    {
        activeMonsters.Add(monster);
    }
    
    public void UnregisterMonster(MonsterController monster)
    {
        activeMonsters.Remove(monster);
    }
    
    private void OnNoteHit(int noteId)
    {
        // 通知所有怪物音符被击打
        // 使用快照避免在遍历时集合被修改导致异常
        var snapshot = activeMonsters.ToArray();
        foreach (var monster in snapshot)
        {
            if (monster != null)
                monster.OnNoteHit(noteId);
        }
    }
}
