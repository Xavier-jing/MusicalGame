using UnityEngine;

public class PlayerHealth:MonoBehaviour
{

    public float maxHealth = 100; //最大血量
    private float currentHealth;  //当前最大血量
    
    //事件：血量变化时通知ui
    public System.Action<float,float> OnHealthChange;

    public void Start()
    {
        currentHealth = maxHealth;//初始化为满血
        OnHealthChange?.Invoke(maxHealth, currentHealth);
    }
    
    //受伤
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        OnHealthChange?.Invoke(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            //玩家死亡逻辑
            Debug.Log("Player Dead!");
        }
    }
    
    //恢复血量
    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        OnHealthChange?.Invoke(currentHealth, maxHealth);
    }
}
