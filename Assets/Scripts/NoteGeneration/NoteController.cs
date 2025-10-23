using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 用于控制实际音符gameobjtc
/// </summary>
public class NoteController : MonoBehaviour
{

    public int noteId;
    public NoteMover noteMover;
    
    private void Update()
    {
       
    }
    public void Initialize(int noteId)
    {
        this.noteId = noteId;
        noteMover = gameObject.GetComponent<NoteMover>();
    }
    
    
    //TODO
    //被正确击打了
    public void BeHit()
    {
        Destroy(gameObject);
    }
    

    //Todo
    //死亡动画之类的
    public void Die()
    {
        Destroy(gameObject);
    }
    
}
