using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseController : MonoBehaviour
{
    private Button _btnContinue;
    private Button _btnRestart;
    private Button _btnSet;
    private Button _btnRtMain;

    [Header("界面引用")]
    public GameObject pausePanel;   // 暂停界面对象

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _btnContinue = root.Q<Button>("Btn_Continue");
        _btnRestart = root.Q<Button>("Btn_Restart");
        _btnSet = root.Q<Button>("Btn_Set");
        _btnRtMain = root.Q<Button>("Btn_RtMain");

        // 注册点击事件
        _btnContinue.clicked += OnContinue;
        _btnRestart.clicked += OnRestart;
        _btnSet.clicked += OnOpenSetting;
        _btnRtMain.clicked += OnReturnMain;
    }

    private void OnDisable()
    {
        // 取消注册，避免重复绑定
        _btnContinue.clicked -= OnContinue;
        _btnRestart.clicked -= OnRestart;
        _btnSet.clicked -= OnOpenSetting;
        _btnRtMain.clicked -= OnReturnMain;
    }

    /// <summary>
    /// 继续游戏
    /// </summary>
    private void OnContinue()
    {
        Time.timeScale = 1f; // 恢复时间
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    /// <summary>
    /// 重新开始当前关卡
    /// </summary>
    private void OnRestart()
    {
        Time.timeScale = 1f; // 确保恢复时间
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    /// <summary>
    /// 打开设置界面
    /// </summary>
    private void OnOpenSetting()
    {
       Time.timeScale = 1f;
       SceneManager.LoadScene("SetScene");
    }

    /// <summary>
    /// 返回主界面
    /// </summary>
    private void OnReturnMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }
}