using UnityEngine;

public class PlayerController:MonoBehaviour
{
    public float runSpeed = 5f;  // 跑步速度
    public float jumpForce = 10f;  // 跳跃力度
    private Rigidbody2D rb;
    private bool isGrounded = true;  // 地面检测

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // 自动跑
        transform.Translate(Vector2.right * runSpeed * Time.deltaTime);

        // 跳跃输入
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    // 地面检测（用 OnCollisionEnter2D）
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }
}
