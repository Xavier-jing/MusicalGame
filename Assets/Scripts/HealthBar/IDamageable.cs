using UnityEngine;
/// <summary>
/// �����ӿڣ��������Ǳ���
/// </summary>
public interface IDamageable
{
    int TotalHP { get; set; }
    int CurrentHP { get; set; }

    void AttackEnemy();
    //�����߼��ڹ��������油ȫ
}
