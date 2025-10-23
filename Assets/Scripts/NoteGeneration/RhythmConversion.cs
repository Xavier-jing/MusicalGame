using UnityEngine;
/// <summary>
/// 工具类 换算器 只接受"."的格式
/// </summary>
public class RhythmConversion
{
    private const int beatLength = 4; //每小节4拍
    private const int eighthLength = 2; //每拍分成2个8分音符

    //转成八分音符
    public static float ToEighthIndex(string rhythmPos)
    {
        rhythmPos = rhythmPos.Trim();
        string[] part = rhythmPos.Split('.');
        int bar = int.Parse(part[0]);
        float beat = part.Length > 1 ? float.Parse(part[1]) : 1f; //拍子是默认从1开始
        float baseEighth = (bar - 1) * beatLength * eighthLength;
        float offset = beat * eighthLength;
        return baseEighth + offset;
    }

    //转成秒数
    public static float ToSeconds(string rhythmPos, float bpm)
    {
        float eighthIndex = ToEighthIndex(rhythmPos);
        float eighthSeconds = 60f / bpm / 2f;
        return (eighthIndex - 1) * eighthSeconds;
    }
}
