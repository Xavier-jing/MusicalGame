using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController:MonoBehaviour
{
    private Button btnStar;
    private Button btnSettings;


    public void OnEnable()
    {
       var root = GetComponent< UIDocument >().rootVisualElement;
       
       btnStar = root.Q<Button>("Btn_Star");
       btnSettings = root.Q<Button>("Btn_Set");

       btnStar.clicked += OnLevelSence;
       btnSettings.clicked += OnOpenSettings;
    }

    public void OnDisable()
    {
        btnStar.clicked -= OnLevelSence;
        btnSettings.clicked -= OnOpenSettings;
    }

    public void OnLevelSence()
    {
        SceneManager.LoadScene("LevelScenes");
    }

    public void OnOpenSettings()
    {
        SceneManager.LoadScene("SetScenes");
    }
}
