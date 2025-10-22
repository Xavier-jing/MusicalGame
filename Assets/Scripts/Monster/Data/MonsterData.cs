using UnityEngine;

namespace Monster
{
    [CreateAssetMenu(fileName = "newMonsterData", menuName = "Data/Monster Data")]
    public class MonsterData : ScriptableObject
    {
        [Header("Idle State")]
        public float idleDuration = 2f;
        
        [Header("Attack State")]
        public float attackRange = 2f;
        public float attackDuration = 1f;
        public int attackDamage = 10;
        public bool canComboAttack = false;
        
        [Header("Fly State")]
        public float flySpeed = 5f;
        public float maxFlyDuration = 5f;
        public float maxFlyHeight = 5f;
        public float directionChangeProbability = 0.1f;
    }
}
