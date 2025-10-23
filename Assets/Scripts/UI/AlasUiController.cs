using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class AlasUiController:MonoBehaviour
{
    private Button btnBack;

    private Button btnMusical;
    private Button btnSkill;
    private Button btnMap;
    
    //假设这些变量存储解锁状态
    private bool isMusicalUnlocked = false;
    private bool isSkillUnlocked = false;
    private bool isMapUnlocked = false;



    private void OnEnable()
    {
        var root =GetComponent<UIDocument>().rootVisualElement;
        
        btnBack = root.Q<Button>("Btn_Back");

        btnMusical = root.Q<Button>("Btn_Musical");
        btnSkill = root.Q<Button>("Btn_Skill");
        btnMap = root.Q<Button>("Btn_Map");
        

        //绑定事件
        btnBack.clicked += OnOpenMain;
        btnMusical.clicked += OnOpenMusical;
        btnSkill.clicked += OnOpenSkill;
        btnMap.clicked += OnOpenMap;
        


        btnBack.clicked += OnOpenLevel;

    }

    private void OnDisable()
    {

        //解绑所有事件
        btnBack.clicked -= OnOpenMain;
        btnMusical.clicked -= OnOpenMusical;
        btnSkill.clicked -= OnOpenSkill;
        btnMap.clicked -= OnOpenMap;
    }

     /// <summary>
    /// 加载解锁状态 - 需要根据您的游戏数据系统来实现
    /// </summary>
    private void LoadUnlockStatus()
    {
        // 示例代码，实际应该从游戏存档中读取
        // isMusicalUnlocked = PlayerPrefs.GetInt("MusicalUnlocked", 0) == 1;
        // isSkillUnlocked = PlayerPrefs.GetInt("SkillUnlocked", 0) == 1;
        // isMapUnlocked = PlayerPrefs.GetInt("MapUnlocked", 0) == 1;
        
        // 临时示例值，用于测试
        isMusicalUnlocked = true;
        isSkillUnlocked = false;
        isMapUnlocked = true;
    }

    /// <summary>
    /// 设置按钮状态
    /// </summary>
    private void SetupButtonStates()
    {
        // 设置音效图鉴按钮状态
        SetupSingleButton(btnMusical, isMusicalUnlocked, "音效图鉴");
        
        // 设置技能道具图鉴按钮状态
        SetupSingleButton(btnSkill, isSkillUnlocked, "技能道具图鉴");
        
        // 设置地图道具图鉴按钮状态
        SetupSingleButton(btnMap, isMapUnlocked, "地图道具图鉴");
    }

    /// <summary>
    /// 设置单个按钮的状态
    /// </summary>
    /// <param name="button">按钮引用</param>
    /// <param name="isUnlocked">是否已解锁</param>
    /// <param name="buttonName">按钮名称（用于调试）</param>
    private void SetupSingleButton(Button button, bool isUnlocked, string buttonName)
    {
        if (button == null)
        {
            Debug.LogWarning($"找不到按钮: {buttonName}");
            return;
        }

        // 设置按钮可用性
        button.SetEnabled(isUnlocked);

        // 根据解锁状态设置样式
        if (isUnlocked)
        {
            // 已解锁：移除灰色样式，添加彩色样式
            button.RemoveFromClassList("locked-button");
            button.AddToClassList("unlocked-button");
        }
        else
        {
            // 未解锁：添加灰色样式
            button.AddToClassList("locked-button");
            button.RemoveFromClassList("unlocked-button");
        }

        Debug.Log($"{buttonName} - 解锁状态: {isUnlocked}");
    }

    /// <summary>
    /// 打开音效图鉴
    /// </summary>
    private void OnOpenMusical()
    {
        if (!isMusicalUnlocked) return;
        
        Debug.Log("打开音效图鉴");
        // SceneManager.LoadScene("MusicalScene");
        // 或者打开对应的UI面板
    }

    /// <summary>
    /// 打开技能道具图鉴
    /// </summary>
    private void OnOpenSkill()
    {
        if (!isSkillUnlocked) return;
        
        Debug.Log("打开技能道具图鉴");
        // SceneManager.LoadScene("SkillScene");
        // 或者打开对应的UI面板
    }

    /// <summary>
    /// 打开地图道具图鉴
    /// </summary>
    private void OnOpenMap()
    {
        if (!isMapUnlocked) return;
        
        Debug.Log("打开地图道具图鉴");
        // SceneManager.LoadScene("MapScene");
        // 或者打开对应的UI面板
    }

    /// <summary>
    /// 更新解锁状态（可以从外部调用）
    /// </summary>
    public void UpdateUnlockStatus(bool musical, bool skill, bool map)
    {
        isMusicalUnlocked = musical;
        isSkillUnlocked = skill;
        isMapUnlocked = map;
        
        SetupButtonStates();
    }

    /// <summary>
    /// 解锁特定图鉴
    /// </summary>
    public void UnlockAlbum(string albumType)
    {
        switch (albumType.ToLower())
        {
            case "musical":
                isMusicalUnlocked = true;
                break;
            case "skill":
                isSkillUnlocked = true;
                break;
            case "map":
                isMapUnlocked = true;
                break;
        }
        
        SetupButtonStates();
        
        // 保存解锁状态到存档
        SaveUnlockStatus();
    }

    /// <summary>
    /// 保存解锁状态 - 需要根据您的游戏数据系统来实现
    /// </summary>
    private void SaveUnlockStatus()
    {
        // 示例代码，实际应该保存到游戏存档中
        // PlayerPrefs.SetInt("MusicalUnlocked", isMusicalUnlocked ? 1 : 0);
        // PlayerPrefs.SetInt("SkillUnlocked", isSkillUnlocked ? 1 : 0);
        // PlayerPrefs.SetInt("MapUnlocked", isMapUnlocked ? 1 : 0);
        // PlayerPrefs.Save();
    }
    public void OnOpenMain()
    {
        SceneManager.LoadScene("MainScenes");

        btnBack.clicked -= OnOpenLevel;
    }

    public void OnOpenLevel()
    {
        SceneManager.LoadScene("LevelScenes");

    }
}
