using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;

public class LoadingSceneController : MonoBehaviour
{
    [Header("UI References")]
    private UIDocument _uiDocument;

    [Header("Scene Settings")] 
    [SerializeField] private string targetSceneName = "MainScenes";
    [SerializeField] private float minLoadingTime = 3f; 
    
    // 静态变量用于记录是否第一次加载
    private static bool _isFirstLoad = true;
    
    // UI元素
    private VisualElement loadingIcon;
    
    // 加载状态
    private float currentProgress = 0f;
    private bool isLoadingComplete = false;
    private bool shouldPlayAnimation = true;

    // 缓存异步加载操作
    private AsyncOperation asyncLoad;

    private void Start()
    {
        // 初始化UI引用
        InitializeUI();
        
        // 决定是否播放动画
        shouldPlayAnimation = _isFirstLoad;
        
        // 开始加载流程
        StartCoroutine(LoadingRoutine());
        
        // 开始loadingIcon的旋转动画
        StartCoroutine(RotateLoadingIcon());
    }

    private void InitializeUI()
    {
        if (_uiDocument == null)
            _uiDocument = GetComponent<UIDocument>();
        
        var root = _uiDocument.rootVisualElement;
        
        // 获取UI元素 - 只需要loadingIcon
        loadingIcon = root.Q<VisualElement>("loadingIcon");
    }

    private IEnumerator LoadingRoutine()
    {
        float elapsedTime = 0f;
        float fakeProgress = 0f;
        
        // 第一阶段：模拟资源加载 (0% - 70%)
        while (fakeProgress < 0.7f)
        {
            elapsedTime += Time.deltaTime;
            fakeProgress = Mathf.Clamp01(elapsedTime / minLoadingTime * 0.7f);
            currentProgress = fakeProgress;
            yield return null;
        }
        
        // 第二阶段：实际场景加载
        asyncLoad = SceneManager.LoadSceneAsync(targetSceneName);
        asyncLoad.allowSceneActivation = false;
        
        // 等待场景加载到90%
        while (asyncLoad.progress < 0.9f)
        {
            float combinedProgress = Mathf.Lerp(0.7f, 0.9f, asyncLoad.progress / 0.9f);
            currentProgress = combinedProgress;
            yield return null;
        }
        
        // 第三阶段：完成加载（90% - 100%）
        currentProgress = 0.9f;
        yield return new WaitForSeconds(0.5f);
        
        // 确保最小加载时间
        float remainingTime = minLoadingTime - elapsedTime;
        if (remainingTime > 0)
            yield return new WaitForSeconds(remainingTime);

        currentProgress = 1f;
        yield return new WaitForSeconds(0.5f);

        // 加载完成后逻辑
        OnLoadingComplete();
    }

    /// <summary>
    /// 控制loadingIcon的旋转动画
    /// </summary>
    private IEnumerator RotateLoadingIcon()
    {
        float rotationSpeed = 180f; // 每秒旋转180度
        
        while (!isLoadingComplete)
        {
            if (loadingIcon != null)
            {
                // 更新旋转角度
                float currentRotation = loadingIcon.resolvedStyle.rotate.angle.value;
                float newRotation = currentRotation + rotationSpeed * Time.deltaTime;
                
                // 应用旋转（使用USS的rotate属性）
                loadingIcon.style.rotate = new Rotate(new Angle(newRotation));
            }
            yield return null;
        }
    }

    private void OnLoadingComplete()
    {
        isLoadingComplete = true;

        if (shouldPlayAnimation && _isFirstLoad)
        {
            // 第一次加载，播放开场动画
            StartCoroutine(PlayOpeningAnimation());
        }
        else
        {
            // 不是第一次加载，直接激活场景
            StartCoroutine(ActivateTargetScene());
        }
    }

    private IEnumerator PlayOpeningAnimation()
    {
        // 这里可以添加其他开场动画逻辑
        // 比如loadingIcon的缩放、淡出等效果
        
        // 标记第一次加载完成
        _isFirstLoad = false;

        // 激活目标场景
        yield return StartCoroutine(ActivateTargetScene());
    }

    private IEnumerator ActivateTargetScene()
    {
        yield return new WaitForSeconds(0.3f);
        
        if (asyncLoad != null)
        {
            asyncLoad.allowSceneActivation = true;

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
        else
        {
            // 如果asyncLoad为null，直接加载场景
            SceneManager.LoadScene(targetSceneName);
        }
    }
}