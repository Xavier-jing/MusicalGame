using UnityEngine;
using System.Collections;

namespace UiController
{
    /// <summary>
    /// 人物放大
    /// </summary>
    public class ClickScaleEffect : MonoBehaviour
    {
        [SerializeField] private float scaleUpFactor = 1.1f; // 放大倍率
        [SerializeField] private float duration = 0.1f;      // 动画时长

        private Vector3 originalScale;
        private bool isScaling = false;

        private void Awake()
        {
            originalScale = transform.localScale;
        }

        private void OnMouseDown() // 鼠标点击 / 移动端点击事件
        {
            if (!isScaling)
                StartCoroutine(ScaleEffect());
        }

        private IEnumerator ScaleEffect()
        {
            isScaling = true;

            Vector3 targetScale = originalScale * scaleUpFactor;
            float timer = 0f;

            // 放大阶段
            while (timer < duration)
            {
                transform.localScale = Vector3.Lerp(originalScale, targetScale, timer / duration);
                timer += Time.deltaTime;
                yield return null;
            }
            transform.localScale = targetScale;

            timer = 0f;

            // 缩小阶段
            while (timer < duration)
            {
                transform.localScale = Vector3.Lerp(targetScale, originalScale, timer / duration);
                timer += Time.deltaTime;
                yield return null;
            }
            transform.localScale = originalScale;

            isScaling = false;
        }
    }
}
