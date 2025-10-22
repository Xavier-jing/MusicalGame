using UnityEngine;
using UnityEngine.UIElements;

public class HealthBarController: MonoBehaviour
{
    [SerializeField]
    private UIDocument uiDocument;

    [SerializeField] 
    private PlayerHealth playerHealth;

    private VisualElement healthBarFill;
    private Label healthText;

    public void OnEnable()
    {
        //获取UI元素
        var root = uiDocument.rootVisualElement;
        healthBarFill = root.Q<VisualElement>("health-bar-fill");
        healthText = root.Q<Label>("health-text");
        
        //监听血量变化
        playerHealth.OnHealthChange += UpdateHealthBar;
        UpdateHealthBar(playerHealth.maxHealth, playerHealth.maxHealth);
    }

    public void OnDisable()
    {
        //移除监听
        playerHealth.OnHealthChange -= UpdateHealthBar;
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        //更新血条比例
        float healthPercentage = (currentHealth / maxHealth);
        healthBarFill.style.width = new StyleLength(Length.Percent(healthPercentage));
        
        //更新血量文本
        healthText.text =$"更新中{healthPercentage}%";
        
    }

}
