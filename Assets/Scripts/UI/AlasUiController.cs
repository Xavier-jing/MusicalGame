using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class AlasUiController:MonoBehaviour
{
    private Button btnBack;


    private void OnEnable()
    {
        var root =GetComponent<UIDocument>().rootVisualElement;
        
        btnBack = root.Q<Button>("Btn_Back");

        btnBack.clicked += OnOpenLevel;
    }

    private void OnDisable()
    {
        btnBack.clicked -= OnOpenLevel;
    }

    public void OnOpenLevel()
    {
        SceneManager.LoadScene("LevelScenes");
    }
}
