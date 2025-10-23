using UnityEngine;
using System;
/// <summary>
/// �Զ����������ݽṹ 10.18
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
    Jump,//������
    Collected,
    Attack1,
    Attack2,
    Attack3
}

[Serializable]
public class MusicNote
{
    public int id;
    public int iconType;//ͼƬ����
    public int noteType; //����������ж�������һ��
    public ActionType actionType;//�����Ķ�������

    public string rhythmPos; //������ĵ�
    public float hitTime;//���ʱ��
    public float appearOffset;//��ǰ���ֵ�����
    public float disappearOffset;//�ӳ���ʧ������
    public float appearTime;//����ʱ��
    public float disappearTime;//��ʧʱ��

    [HideInInspector]
    public NoteState state = NoteState.Idle;
    [HideInInspector]
    public bool hasBeenJudged = false;

    public Vector2 spawnPos; //������
    public Vector2 targetPos; //�ж���λ��

    public void CalculateTime(float bpm)
    {
        hitTime = RhythmConversion.ToSeconds(rhythmPos, bpm);
        appearTime = hitTime - appearOffset;
        disappearTime = hitTime + disappearOffset;
    }
}
