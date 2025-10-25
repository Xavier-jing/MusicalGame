using UnityEngine;
/// <summary>
/// 攻击接口，给敌人那边用
/// </summary>
public interface IDamageable
{
    int TotalHP { get; set; }
    int CurrentHP { get; set; }

    void AttackEnemy();
    //具体逻辑在怪物类里面补全
}