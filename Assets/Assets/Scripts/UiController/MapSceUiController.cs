using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace UiController
{
    

    /// <summary>
    /// 地图Ui控制
    /// </summary>
    public class MapSceUiController : MonoBehaviour
    {
        private Button btnBack;


        public void OnEnable()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;
            btnBack = root.Q<Button>("Btn_Back");

            btnBack.clicked += OnOpenAlas;
        }

        public void OnDisable()
        {
            btnBack.clicked -= OnOpenAlas;
        }

        public void OnOpenAlas()
        {
            SceneManager.LoadScene("AlasScene");
        }
    }

}