using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace UiController
{
    /// <summary>
    /// 音乐图集控制
    /// </summary>
    public class MusicalUiController : MonoBehaviour
    {
        private Button _btnBack;

        public void OnEnable()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            _btnBack = root.Q<Button>("Btn_Back");

            _btnBack.clicked += OnOpenAlas;

        }

        private void OnDisable()
        {
            _btnBack.clicked -= OnOpenAlas;
        }

        public void OnOpenAlas()
        {
            SceneManager.LoadScene("AlasScene");
        }
    }
}
