using UnityEngine;
/// <summary>
/// 自定义音符数据结构 10.18
/// </summary>
public enum MushroomState
{
    Idle,       
    Active,     
    Judged,   
    Missed
}

[System.Serializable]
public class MusicNote
{
    public int id;
    public int lane; //有两个键，判定是用哪一个键
    public float appearTime;
    public float hitTime;
    public float disappearTime;
    public Vector3 spawnPos;       
    public Vector3 targetPos;     
    [HideInInspector] 
    public MushroomState state = MushroomState.Idle;
    [HideInInspector] 
    public bool hasBeenJudged = false;
}
