using UnityEngine;

public class AutoMovingCharacter : MonoBehaviour
{
    [Header("移动设置")]
    public float jumpForce = 10f;      // 跳跃力度

    [Header("检测设置")]
    public float obstacleCheckDistance = 0.6f; // 障碍物检测距离
    public LayerMask groundLayer;              // 地面层
    public LayerMask obstacleLayer;            // 障碍层
    public Transform groundCheck;              // 地面检测点（脚下）
    public Transform frontCheck;               // 前方检测点（角色前面）

    [Header("检测半径")]
    public float checkRadius = 0.6f;           // 地面检测半径

    [Header("轨道设置")] 
    public int currentLane = 1;    //当前轨迹
    public float laneWidth = 2f;   //轨道宽度
    public float laneChangeSpeed = 10f; //切换轨道速度
    
    
    private Rigidbody2D rb;
    private bool isGrounded;
    private Vector3 targetPosition;
    private bool isChangingLane = false;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
    }

    public void Update()
    {
        CheckGround();
        HandleInput();
        DetectAndJump();
        UpdateLanePosition();
    }

    // 处理玩家输入
    public void HandleInput()
    {
        // 轨道切换输入
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoveToLane(currentLane - 1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            MoveToLane(currentLane + 1);
        }

        // 跳跃输入
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            Jump();
        }
    }

    // 移动到指定轨道
    public void MoveToLane(int lane)
    {
        if (lane < 0 || lane > 2 || lane == currentLane || isChangingLane)
            return;

        currentLane = lane;
        float targetX = (lane - 1) * laneWidth; // 计算目标X位置
        targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        isChangingLane = true;
    }

    // 更新轨道位置
    public void UpdateLanePosition()
    {
        if (isChangingLane)
        {
            // 平滑移动到目标轨道
            transform.position = Vector3.MoveTowards(
                transform.position, 
                targetPosition, 
                laneChangeSpeed * Time.deltaTime
            );

            // 如果到达目标位置，停止移动
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isChangingLane = false;
            }
        }

        // 保持Y轴物理运动，但锁定X轴位置（除非正在切换轨道）
        if (!isChangingLane)
        {
            // 锁定水平位置，只允许垂直移动
            transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
        }
    }

    // 检测地面
    public void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    // 检测障碍物并自动跳跃（可选功能）
    public void DetectAndJump()
    {
        // 用射线检测前方障碍
        RaycastHit2D hit = Physics2D.Raycast(frontCheck.position, Vector2.right, obstacleCheckDistance, obstacleLayer);
        Debug.DrawRay(frontCheck.position, Vector2.right * obstacleCheckDistance, Color.red);

        // 如果检测到障碍且在地面上，自动跳跃
        if (hit.collider != null && isGrounded)
        {
            Jump();
        }
    }

    public void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    // 可视化轨道（在Scene视图中显示）
    void OnDrawGizmosSelected()
    {
        // 绘制轨道线
        Gizmos.color = Color.blue;
        for (int i = 0; i < 3; i++)
        {
            float xPos = (i - 1) * laneWidth;
            Vector3 start = new Vector3(xPos, transform.position.y - 5f, 0);
            Vector3 end = new Vector3(xPos, transform.position.y + 5f, 0);
            Gizmos.DrawLine(start, end);
        }
    }
}


