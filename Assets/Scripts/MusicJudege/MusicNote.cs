using UnityEngine;
using System;
/// <summary>
/// 自定义音符数据结构 10.18
/// </summary>
public enum NoteState
{
    Idle,
    Active,
    Judged,
    Missed
}

public enum ActionType
{
    None,
    Jump,//跳过？
    Collected,
    Attack1,
    Attack2,
    Attack3
}

[Serializable]
public class MusicNote
{
    public int id;
    public int iconType;//图片索引
    public int noteType; //有五个键，判定是用哪一个
    public ActionType actionType;//触发的动作类型

    public string rhythmPos; //传入节拍点
    public float hitTime;//打击时间
    public float appearOffset;//提前出现的秒数
    public float disappearOffset;//延迟消失的秒数
    public float appearTime;//出现时间
    public float disappearTime;//消失时间

    [HideInInspector]
    public NoteState state = NoteState.Idle;
    [HideInInspector]
    public bool hasBeenJudged = false;

    public Vector2 spawnPos; //出生点
    public Vector2 targetPos; //判定区位置

    public void CalculateTime(float bpm)
    {
        hitTime = RhythmConversion.ToSeconds(rhythmPos, bpm);
        appearTime = hitTime - appearOffset;
        disappearTime = hitTime + disappearOffset;
    }
}
