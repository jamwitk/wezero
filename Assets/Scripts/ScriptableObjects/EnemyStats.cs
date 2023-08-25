using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStats", order = 1)]
    public class EnemyStats : ScriptableObject
    {
        [SerializeField] private int health;
        [SerializeField] private int speed;
        [SerializeField] private int attackDamage;
        [SerializeField] private int attackRange;
        [SerializeField] private int attackSpeed;
        [SerializeField] private int chaseRange;
        [SerializeField] private int deathTime;
        [SerializeField] private int attackCooldown;
        [SerializeField] private GameObject bulletPrefab;
        
        public int Health => health;
        public int Speed => speed;
        public int AttackDamage => attackDamage;
        public int AttackRange => attackRange;
        public int AttackSpeed => attackSpeed;
        public int ChaseRange => chaseRange;
        public int DeathTime => deathTime;
        public int AttackCooldown => attackCooldown;
        public GameObject BulletPrefab => bulletPrefab;
        
        public UnityAction<float> OnHealthChanged;
        public UnityAction OnDeath;
        
    }
}
