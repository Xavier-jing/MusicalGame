using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
/// <summary>
/// 地图自动向左走
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
