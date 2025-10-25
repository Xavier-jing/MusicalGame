using UnityEngine; 
using UnityEngine.SceneManagement; 
using UnityEngine.UIElements;

namespace UiController
{
    /// <summary>
    /// 主界面UI控制
    /// </summary>
    public class BeginUiController : MonoBehaviour
    {
        private Button btnStar; 
        private Button btnSettings;

        public void OnEnable()
        {
            var root = GetComponent< UIDocument >().rootVisualElement; btnStar = root.Q<Button>("Btn_Begin"); btnSettings = root.Q<Button>("Btn_Set"); btnStar.clicked += OnLoadinglSences; btnSettings.clicked += OnOpenSettings;
        }

        public void OnDisable()
        {
            btnStar.clicked -= OnLoadinglSences; btnSettings.clicked -= OnOpenSettings;
        }

        public void OnLoadinglSences()
        {
            SceneManager.LoadScene("LoadingScene");
        }

        public void OnOpenSettings()
        {
            // 使用PlayerPrefs记录当前场景
            string currentScene = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("PreviousScene", currentScene);
            PlayerPrefs.Save();
    
            SceneManager.LoadScene("SetScene");
        }
    }
}
