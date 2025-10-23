using UnityEngine;
/// <summary>
/// ������ ������ ֻ����"."�ĸ�ʽ
/// </summary>
public class RhythmConversion
{
    private const int beatLength = 4; //ÿС��4��
    private const int eighthLength = 2; //ÿ�ķֳ�2��8������

    //ת�ɰ˷�����
    public static float ToEighthIndex(string rhythmPos)
    {
        rhythmPos = rhythmPos.Trim();
        string[] part = rhythmPos.Split('.');
        int bar = int.Parse(part[0]);
        float beat = part.Length > 1 ? float.Parse(part[1]) : 1f; //������Ĭ�ϴ�1��ʼ
        float baseEighth = (bar - 1) * beatLength * eighthLength;
        float offset = beat * eighthLength;
        return baseEighth + offset;
    }

    //ת������
    public static float ToSeconds(string rhythmPos, float bpm)
    {
        float eighthIndex = ToEighthIndex(rhythmPos);
        float eighthSeconds = 60f / bpm / 2f;
        return (eighthIndex - 1) * eighthSeconds;
    }
}
