using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
/// <summary>
/// ��ͼ�Զ�������
/// </summary>
public class GroundAutoMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
