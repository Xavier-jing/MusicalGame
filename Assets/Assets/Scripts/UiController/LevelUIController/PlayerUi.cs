using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
   private Button rhythm1Button;
   private Button rhythm2Button;
   private Button _attack1Button;
   private Button _attack2Button;
   private Button _attack3Button;
   private Button _btnPause;

   public Player player;

   public void OnEnable()
   {
      var root = GetComponent<UIDocument>().rootVisualElement;
      
      rhythm1Button = root.Q<Button>("Btn_Rhythm1");
      rhythm2Button = root.Q<Button>("Btn_Rhythm2");
      
      _attack1Button = root.Q<Button>("Btn_AttackSkill");
      _attack2Button = root.Q<Button>("Btn_SecSkill");
      _attack3Button = root.Q<Button>("Btn_Ultimate");
      
      _btnPause = root.Q<Button>("Btn_pause");

      
      //_attack1Button.clicked += () => player.OnAttack1Input();
      //_attack2Button.clicked += () => player.OnAttack2Input();
      //_attack3Button.clicked += () => player.OnAttack3Input();

      _btnPause.clicked += OnOpendPause;

   }

   public void OnDisable()
   {
      _btnPause.clicked -= OnOpendPause;
   }
   

   private void OnOpendPause()
   {
      SceneManager.LoadScene("PauseMenuScene");
   }
}
