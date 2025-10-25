using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


namespace UiController
{
    /// <summary>
    /// 图集Ui控制
    /// </summary>
    public class AlasUiController : MonoBehaviour
    {
        private Button _buttonMusical;
        private Button _buttonSkill;
        private Button _buttonMap;

        private void Start()
        {
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            var root = GetComponentInParent<UIDocument>().rootVisualElement;
        
            _buttonMusical = root.Q<Button>("Btn_Musical");
            _buttonSkill = root.Q<Button>("Btn_Skill");
            _buttonMap = root.Q<Button>("Btn_Map");

            _buttonMusical.clicked += OnOpenMusicScene;
            _buttonSkill.clicked += OnOpenSkillScene;
            _buttonMap.clicked += OnOpenMapScene;
        }

        public void OnDisable()
        {
            _buttonMusical.clicked -= OnOpenMusicScene;
            _buttonSkill.clicked -= OnOpenSkillScene;
            _buttonMap.clicked -= OnOpenMapScene;
        }

        public void OnOpenMusicScene()
        {
            SceneManager.LoadScene("MusicalScene");
        }

        public void OnOpenSkillScene()
        {
            SceneManager.LoadScene("SkillScene");
        }

        public void OnOpenMapScene()
        {
            SceneManager.LoadScene("MapScene");
        }
    }
}
