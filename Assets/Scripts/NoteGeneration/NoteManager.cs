using System;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;
    
    public NoteProcessor noteProcessor;
    public NoteSpawner noteSpawner;
    public List<NoteController> NoteControllers;//场上所有存在的音符对象控制器

    public void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        // 1. 更新音符状态
        noteProcessor.ProcessNote();

        // 2. 生成对应的可视化音符
        noteSpawner.UpdateSpawner(noteProcessor.audioSource.time);
    }


    //通过id，拿到对应物体
    public NoteController GetControllerByNoteId(int noteId)
    {

        foreach (var noteController in NoteControllers) {
            if (noteController.noteId == noteId) {
                return noteController;
            }
            
        }

        return null;

    }
    
}

