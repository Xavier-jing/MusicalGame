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
    public List<NoteController> NoteControllers;//�������д��ڵ��������������

    public void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        // 1. ��������״̬
        noteProcessor.ProcessNote();

        // 2. ���ɶ�Ӧ�Ŀ��ӻ�����
        noteSpawner.UpdateSpawner(noteProcessor.audioSource.time);
    }


    //ͨ��id���õ���Ӧ����
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

