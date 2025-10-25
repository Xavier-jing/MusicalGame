using UnityEngine;
using System.Collections;
/// <summary>
/// 震动交互
/// </summary>
public static class HapticManager
{
    public static void PlayHaptic(float strength = 1f)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        // Android 使用 Vibrator 系统服务
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");

        if (vibrator != null)
        {
            long duration = (long)(30 + 50 * Mathf.Clamp01(strength)); // 30~80ms
            vibrator.Call("vibrate", duration);
        }
#elif UNITY_IOS && !UNITY_EDITOR
        // iOS 简单振动
        Handheld.Vibrate();
#else
        // 编辑器调试模式
        Debug.Log($"[Haptic] 模拟震动 (强度: {strength})");
#endif
    }

    public static IEnumerator PlayHapticWithDelay(float delay, float strength)
    {
        yield return new WaitForSeconds(delay);
        PlayHaptic(strength);
    }
}
