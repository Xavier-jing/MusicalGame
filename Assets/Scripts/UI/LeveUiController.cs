using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class LeveUiController: MonoBehaviour
{
    private Button btnSettings;
    private Button btnAlas;
   

    public void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        
        btnSettings = root.Q<Button>("Btn_Set");
        btnAlas = root.Q<Button>("Btn_Alas");
        btnSettings.clicked += OnOpenSettings;
        btnAlas.clicked += OnOpenAlats;

    }

    public void OnDisable()
    {
        btnSettings.clicked -= OnOpenSettings;
        btnAlas.clicked -= OnOpenAlats;
    }
   
    public void OnOpenSettings()
    {
        SceneManager.LoadScene("SetScenes");
    }

    public void OnOpenAlats()
    {
        SceneManager.LoadScene("AlasScenes");
    }

   
}
