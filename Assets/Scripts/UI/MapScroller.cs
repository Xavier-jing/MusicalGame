using UnityEngine;
using System.Collections.Generic;

public class MapScroller:MonoBehaviour
{
    [Header("滚动设置")]
    public float scrollSpeed = 5f;           // 滚动速度
    public bool autoScroll = true;           // 是否自动滚动
    
    [Header("地图分段")]
    public GameObject[] mapSegments;         // 地图分段预制体
    public float segmentLength = 20f;        // 分段长度
    
    [Header("游戏控制")]
    public bool isGameRunning = true;        // 游戏是否进行中
    
    private Vector3 startPosition;
    private int currentSegment = 0;
    private Queue<GameObject> activeSegments = new Queue<GameObject>();
    private float totalScrollDistance = 0f;

    void Start()
    {
        startPosition = transform.position;
        InitializeMap();
    }

    void Update()
    {
        if (autoScroll && isGameRunning)
        {
            ScrollMap();
            CheckSegmentRecycling();
        }
    }

    void ScrollMap()
    {
        // 地图向左移动，创造前进效果
        float scrollAmount = scrollSpeed * Time.deltaTime;
        transform.Translate(Vector3.left * scrollAmount);
        totalScrollDistance += scrollAmount;
    }

    void InitializeMap()
    {
        // 初始生成2-3个地图分段
        for (int i = 0; i < 3; i++)
        {
            SpawnNextSegment();
        }
    }

    void SpawnNextSegment()
    {
        if (mapSegments.Length == 0) return;
        
        GameObject segment = Instantiate(
            mapSegments[currentSegment % mapSegments.Length],
            Vector3.zero, 
            Quaternion.identity, 
            transform
        );
        
        segment.transform.localPosition = new Vector3(
            currentSegment * segmentLength, 
            0, 
            0
        );
        
        activeSegments.Enqueue(segment);
        currentSegment++;
    }

    void CheckSegmentRecycling()
    {
        if (activeSegments.Count > 0)
        {
            GameObject firstSegment = activeSegments.Peek();
            float segmentEndX = firstSegment.transform.position.x + segmentLength / 2;
            
            // 如果分段完全离开屏幕，回收并生成新的
            if (segmentEndX < -10f) // -10f是屏幕外缓冲距离
            {
                Destroy(activeSegments.Dequeue());
                SpawnNextSegment();
            }
        }
    }

    // 用于同步音乐节奏调整速度
    public void SetScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
    }

    // 暂停滚动（用于游戏暂停时）
    public void PauseScroll(bool pause)
    {
        autoScroll = !pause;
    }

    // 获取总滚动距离（可用于计算分数）
    public float GetTotalScrollDistance()
    {
        return totalScrollDistance;
    }
}
