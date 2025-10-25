using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdvancedFrameAnimation : MonoBehaviour
{
    public enum PlayMode
    {
        Once,           // 播放一次
        Loop,           // 循环播放
        PingPong,       // 来回播放
        Random          // 随机播放
    }
    
    [Header("帧序列")]
    public Sprite[] animationFrames;
    
    [Header("播放设置")]
    public PlayMode playMode = PlayMode.Loop;
    public float frameRate = 12f;
    public bool autoPlay = true;
    
    [Header("事件")]
    public UnityEngine.Events.UnityEvent onAnimationComplete;
    public UnityEngine.Events.UnityEvent onAnimationLoop;
    
    private Image uiImage;
    private SpriteRenderer spriteRenderer;
    private int currentIndex = 0;
    private bool isPlaying = false;
    private bool isReversing = false;
    private Coroutine animationCoroutine;
    
    void Start()
    {
        uiImage = GetComponent<Image>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (autoPlay)
        {
            Play();
        }
    }
    
    public void Play()
    {
        if (animationFrames == null || animationFrames.Length == 0)
        {
            Debug.LogError("没有设置动画帧！");
            return;
        }
        
        Stop();
        isPlaying = true;
        animationCoroutine = StartCoroutine(Animate());
    }
    
    public void Stop()
    {
        isPlaying = false;
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
            animationCoroutine = null;
        }
    }
    
    public void Pause()
    {
        isPlaying = false;
    }
    
    public void Resume()
    {
        if (!isPlaying && animationCoroutine == null)
        {
            isPlaying = true;
            animationCoroutine = StartCoroutine(Animate());
        }
    }
    
    IEnumerator Animate()
    {
        float frameDelay = 1f / frameRate;
        
        while (isPlaying)
        {
            UpdateFrame();
            
            // 根据播放模式更新索引
            switch (playMode)
            {
                case PlayMode.Once:
                    if (currentIndex >= animationFrames.Length - 1)
                    {
                        onAnimationComplete?.Invoke();
                        yield break;
                    }
                    currentIndex++;
                    break;
                    
                case PlayMode.Loop:
                    currentIndex = (currentIndex + 1) % animationFrames.Length;
                    if (currentIndex == 0)
                        onAnimationLoop?.Invoke();
                    break;
                    
                case PlayMode.PingPong:
                    if (isReversing)
                    {
                        currentIndex--;
                        if (currentIndex <= 0)
                        {
                            currentIndex = 0;
                            isReversing = false;
                            onAnimationLoop?.Invoke();
                        }
                    }
                    else
                    {
                        currentIndex++;
                        if (currentIndex >= animationFrames.Length - 1)
                        {
                            currentIndex = animationFrames.Length - 1;
                            isReversing = true;
                        }
                    }
                    break;
                    
                case PlayMode.Random:
                    currentIndex = Random.Range(0, animationFrames.Length);
                    break;
            }
            
            yield return new WaitForSeconds(frameDelay);
        }
    }
    
    void UpdateFrame()
    {
        if (animationFrames == null || animationFrames.Length == 0) return;
        
        Sprite currentFrame = animationFrames[Mathf.Clamp(currentIndex, 0, animationFrames.Length - 1)];
        
        if (uiImage != null)
            uiImage.sprite = currentFrame;
        if (spriteRenderer != null)
            spriteRenderer.sprite = currentFrame;
    }
    
    // 设置特定帧
    public void SetFrame(int frameIndex)
    {
        if (animationFrames != null && frameIndex >= 0 && frameIndex < animationFrames.Length)
        {
            currentIndex = frameIndex;
            UpdateFrame();
        }
    }
    
    // 设置帧率
    public void SetFrameRate(float newFrameRate)
    {
        frameRate = newFrameRate;
    }
    
    void OnDestroy()
    {
        Stop();
    }
}