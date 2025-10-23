using UnityEngine;

public class MushroomEffect : MonoBehaviour
{
    public float radius = 1.2f;    // 半圆半径
    public float speed = 1.0f;     // 速度因子（越大越快）
    private Vector2 origin;

    void Start()
    {
        origin = transform.position; // 以初始位置为圆心
    }

    void Update()
    {
        // t 在 [0,1] 往返：0->1->0->1...
        float t = Mathf.PingPong(Time.time * speed, 1f);

        // 将 t 映射到角度范围 [π, 0]（注意顺序）
        float angle = Mathf.Lerp(Mathf.PI, 0f, t);

        // 上半圆：x = cos(angle)*r, y = sin(angle)*r
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.position = origin + new Vector2(x, y);
    }
}

