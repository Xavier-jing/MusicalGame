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
        // 1. 更新音符状态
        noteProcessor.ProcessNote();

        // 2. 生成对应的可视化音符
        noteSpawner.UpdateSpawner(noteProcessor.audioSource.time);
    }
}

