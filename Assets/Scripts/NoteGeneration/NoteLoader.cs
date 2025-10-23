using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 工具类 读取csv文件内容生成MusicNote列表
/// </summary>
public class NoteLoader
{
    public static List<MusicNote> LoadCSV(TextAsset csv, float bpm)
    {
        List<MusicNote> notes = new List<MusicNote>();
        string[] lines = csv.text.Split('\n');//按行划分
        bool isFirst = true;
        foreach (string line in lines)
        {
            string line1 = line.Trim();
            if (string.IsNullOrEmpty(line1)) continue; //跳空行
            if (isFirst) { isFirst = false; continue; } //跳第一行
            string[] parts = line1.Split(',');
            MusicNote note = new MusicNote
            {
                id = int.Parse(parts[0]),
                noteType = int.Parse(parts[1]),
                rhythmPos = parts[2],
                actionType = (ActionType)Enum.Parse(typeof(ActionType), parts[3], true),
                appearOffset = float.Parse(parts[4]),
                disappearOffset = float.Parse(parts[5]),
                iconType = int.Parse(parts[6]),
                state = NoteState.Idle,
                hasBeenJudged = false
            };
            note.CalculateTime(bpm);
            notes.Add(note);
            Debug.Log($"{note.id} rhythm:{note.rhythmPos} seconds:{RhythmConversion.ToSeconds(note.rhythmPos, bpm)}");
        }
        return notes;
    }
}
