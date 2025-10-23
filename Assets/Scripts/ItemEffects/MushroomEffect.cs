using UnityEngine;

public class MushroomEffect : MonoBehaviour
{
    public float radius = 1.2f;    // ��Բ�뾶
    public float speed = 1.0f;     // �ٶ����ӣ�Խ��Խ�죩
    private Vector2 origin;

    void Start()
    {
        origin = transform.position; // �Գ�ʼλ��ΪԲ��
    }

    void Update()
    {
        // t �� [0,1] ������0->1->0->1...
        float t = Mathf.PingPong(Time.time * speed, 1f);

        // �� t ӳ�䵽�Ƕȷ�Χ [��, 0]��ע��˳��
        float angle = Mathf.Lerp(Mathf.PI, 0f, t);

        // �ϰ�Բ��x = cos(angle)*r, y = sin(angle)*r
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.position = origin + new Vector2(x, y);
    }
}

