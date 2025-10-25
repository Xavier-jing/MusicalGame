using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/// <summary>
/// 主界面UI控制
/// </summary>
public class MainUiController : MonoBehaviour
{
    private Button btnSettings;
    private Button btnAlas;
    private Button btnChapter1,btnChapter2,btnChapter3;


    public void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        
        btnSettings = root.Q<Button>("Btn_Set"); 
        btnAlas = root.Q<Button>("Btn_Alas");
        btnChapter1 = root.Q<Button>("Btn_Chapter1");
        btnChapter2 = root.Q<Button>("Btn_Chapter2");
        btnChapter3 = root.Q<Button>("Btn_Chapter3");
        
        //注册按钮事件
        btnSettings.clicked += OnOpenSettings; 
        btnAlas.clicked += OnOpenAlats;
        btnChapter1.clicked += OnOpenLevel1;
        btnChapter2.clicked += OnOpenLevel2;
        btnChapter3.clicked += OnOpenLevel3;
        
        //初始化章节状态
        InitChapterLockState();
    }

    public void OnDisable()
    {
        btnSettings.clicked -= OnOpenSettings;
        btnAlas.clicked -= OnOpenAlats;
        btnSettings.clicked -= OnOpenLevel1;
        btnChapter2.clicked -= OnOpenLevel2;
        btnChapter3.clicked -= OnOpenLevel3;
    }

    /// <summary>
    /// 初始化章节锁定状态
    /// </summary>

    private void InitChapterLockState()
    {
        //如果第一次运行，默许只解锁第一章
        if (!PlayerPrefs.HasKey("Chapter1UnlockStated"))
        {
            PlayerPrefs.SetInt("Chapter1UnlockStated", 1);
            PlayerPrefs.SetInt("Chapter2UnlockStated", 0);
            PlayerPrefs.SetInt("Chapter3UnlockStated", 0);
            PlayerPrefs.Save();
        }
        
        //设置每个章节按钮状态
        SetButtonLockState(btnChapter1, PlayerPrefs.GetInt("Chapter1UnlockStated") ==1);
        SetButtonLockState(btnChapter2, PlayerPrefs.GetInt("Chapter2UnlockStated") ==1);
        SetButtonLockState(btnChapter3, PlayerPrefs.GetInt("Chapter3UnlockStated") ==1);
        
    }
    /// <summary>
    /// 设置按钮的锁定/解锁状态（控制颜色和可点击性）
    /// </summary>
    private void SetButtonLockState(Button button, bool isUnlocked)
    {
        if (isUnlocked)
        {
            // 解锁状态：正常颜色，可点击
            button.style.opacity = 1f;
            button.SetEnabled(true);
        }
        else
        {
            // 锁定状态：变灰，不可点击
            button.style.opacity = 0.5f;
            button.SetEnabled(false);
        }
    }
    public void OnOpenSettings()
    {
        // 使用PlayerPrefs记录当前场景
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("PreviousScene", currentScene);
        PlayerPrefs.Save();
    
        SceneManager.LoadScene("SetScene");
    }

    public void OnOpenAlats()
    {
        SceneManager.LoadScene("AlasScene");
    }

    public void OnOpenLevel1()
    {
        SceneManager.LoadScene("Level1Scene");
    }

    public void OnOpenLevel2()
    {
        SceneManager.LoadScene("Level2Scene");
    }

    public void OnOpenLevel3()
    {
        SceneManager.LoadScene("Level3Scene");
    }
}