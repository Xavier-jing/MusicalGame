using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class NoteManager : MonoBehaviour
{
    public NoteProcessor noteProcessor;
    public NoteSpawner noteSpawner;
    private void Update()
    {
        // 1. ��������״̬
        noteProcessor.ProcessNote();

        // 2. ���ɶ�Ӧ�Ŀ��ӻ�����
        noteSpawner.UpdateSpawner(noteProcessor.audioSource.time);
    }
}

