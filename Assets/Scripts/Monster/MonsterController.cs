using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [Header("Monster Info")]
    public MonsterData monsterData;
    
    [Header("Movement")]
    [SerializeField] private Vector2 targetPos;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isMoving = false;
    
    [Header("Debug Info - Read Only")]
    [SerializeField] private int monsterId;
    [SerializeField] private MonsterType monsterType;
    [SerializeField] private List<int> requiredNoteIds = new List<int>();
    [SerializeField] private List<int> hitNoteIdsList = new List<int>();
    [SerializeField] private string hitStatus;
    
    public HashSet<int> hitNoteIds = new HashSet<int>();
    
    private void Update()
    {
        // 独立移动，模拟音符的移动
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPos) < 0.05f)
            {
                isMoving = false;
                
            }
        }
    }
    
    public void Initialize(MonsterData data, NoteController noteController)
    {
        monsterData = data;
        
        // 获取音符的移动数据
        NoteMover noteMover = noteController.noteMover;
        if (noteMover != null)
        {
            // 通过公开字段获取移动参数
            targetPos = noteMover.GetTargetPosition();
            moveSpeed = noteMover.GetMoveSpeed();
            isMoving = true;
        }
        
        UpdateDebugInfo();
    }
    
    public void OnNoteHit(int noteId)
    {
        if (monsterData.noteIds.Contains(noteId))
        {
            hitNoteIds.Add(noteId);
            UpdateDebugInfo();
            
            // 检查是否所有音符都被击打
            if (hitNoteIds.Count >= monsterData.noteIds.Count)
            {
                Die();
            }
        }
    }
    
    private void UpdateDebugInfo()
    {
        if (monsterData != null)
        {
            monsterId = monsterData.monsterId;
            monsterType = monsterData.monsterType;
            requiredNoteIds = monsterData.noteIds.ToList();
            hitNoteIdsList = hitNoteIds.ToList();
            hitStatus = $"{hitNoteIds.Count}/{monsterData.noteIds.Count} notes hit";
        }
    }
    
    public void Attack()
    {
        Debug.Log($"Monster {monsterData} attacks player!");
        // TODO: 实现攻击逻辑
    }
    
    public void Die()
    {
        Debug.Log($"Monster {monsterData} died!");
        MonsterManager.Instance.UnregisterMonster(this);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Attack();
        }
    }
}
