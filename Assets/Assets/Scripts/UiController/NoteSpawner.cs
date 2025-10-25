using UnityEngine;

namespace UiController
{
    /// <summary>
    /// 音符控制
    /// </summary>
    public class NotePathSpawner : MonoBehaviour
{
    [Header("音符素材")]
    public Sprite[] noteSprites;
    public GameObject notePrefab;

    [Header("路径控制点")]
    public Transform[] controlPoints; // 在场景中手动摆放路径点

    [Header("音符参数")]
    public int noteCount = 35;
    public float waveAmplitude = 0.3f; // 微小漂浮上下
    public Vector2 floatRange = new Vector2(0.05f, 0.2f);
    public Vector2 speedRange = new Vector2(0.5f, 1.5f);
    

    
    [Header("渲染设置")]
    public string sortingLayerName = "Notes";
    public int sortingOrder = 0;

    void Start()
    {
        if (controlPoints == null || controlPoints.Length < 2)
        {
            Debug.LogWarning("请在 Inspector 中指定至少两个控制点！");
            return;
        }

        for (int i = 0; i < noteCount; i++)
        {
            float t = (float)i / (noteCount - 1);
            Vector3 pos = GetCatmullRomPosition(t);
            GameObject note = Instantiate(notePrefab, pos, Quaternion.identity, transform);

            // 随机 Sprite
            var sr = note.GetComponent<SpriteRenderer>();
            sr.sprite = noteSprites[Random.Range(0, noteSprites.Length)];
            
            // 设置渲染层级
            sr.sortingLayerName = sortingLayerName;
            sr.sortingOrder = sortingOrder;

            // 随机大小与透明度
            float scale = Random.Range(0.8f, 1.2f);
            note.transform.localScale = Vector3.one * scale;
            Color color = sr.color;
            color.a = Random.Range(0.7f, 1f);
            sr.color = color;

            // 浮动脚本
            var floatScript = note.GetComponent<FloatingNote2D>();
            floatScript.xAmplitude = Random.Range(floatRange.x, floatRange.y);
            floatScript.yAmplitude = Random.Range(floatRange.x, floatRange.y);
            floatScript.speed = Random.Range(speedRange.x, speedRange.y);
        }
    }

    // Catmull-Rom 样条曲线插值
    Vector3 GetCatmullRomPosition(float t)
    {
        int numSections = controlPoints.Length - 3;
        int currPt = Mathf.Min(Mathf.FloorToInt(t * numSections), numSections - 1);
        float u = t * numSections - currPt;

        Vector3 a = controlPoints[currPt].position;
        Vector3 b = controlPoints[currPt + 1].position;
        Vector3 c = controlPoints[currPt + 2].position;
        Vector3 d = controlPoints[currPt + 3].position;

        return 0.5f * (
            (-a + 3f * b - 3f * c + d) * (u * u * u)
            + (2f * a - 5f * b + 4f * c - d) * (u * u)
            + (-a + c) * u
            + 2f * b);
    }

    // Scene视图可视化曲线
    private void OnDrawGizmos()
    {
        if (controlPoints == null || controlPoints.Length < 4)
            return;

        Gizmos.color = Color.cyan;
        Vector3 prevPos = controlPoints[1].position;
        int steps = 50;

        for (int i = 1; i <= steps; i++)
        {
            float t = i / (float)steps;
            Vector3 newPos = GetCatmullRomPosition(t);
            Gizmos.DrawLine(prevPos, newPos);
            prevPos = newPos;
        }
    }
}

}
