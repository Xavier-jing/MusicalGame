using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MusicalUiController:MonoBehaviour
{
    private Button btnBack;

    public void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        
        btnBack = root.Q<Button>("Btn_Back");

        btnBack.clicked += OnOpenAlas;
        
    }

    private void OnDisable()
    {
        btnBack.clicked -= OnOpenAlas;
    }

    public void OnOpenAlas()
    {
        SceneManager.LoadScene("AlasScenes");
    }
}
