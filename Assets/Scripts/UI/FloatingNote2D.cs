using UnityEngine;

/// <summary>
/// 音符自动漂浮
/// </summary>
public class FloatingNote2D:MonoBehaviour
{
    public float xAmplitude = 0.1f; //左右浮动幅度
    public float yAmplitude = 0.2f; //上下浮动幅度
    public float speed = 1f;        //浮动速度
    private Vector3 startPos;
    private float offset;

    public void Start()
    {
        startPos = transform.position;
        offset = Random.Range(0f,Mathf.PI*2f); //每个音符不同相位
    }

    public void Update()
    {
        float newX = startPos.x + Mathf.Sin(Time.time * speed) * xAmplitude;
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * yAmplitude;
        transform.position = new Vector3(newX, newY, startPos.z);
    }

}

