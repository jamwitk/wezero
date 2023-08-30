using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStats", order = 1)]
    public class EnemyStats : ScriptableObject
    {
        [SerializeField] private int health;
        [SerializeField] private float speed;
        [SerializeField] private float attackDamage;
        [SerializeField] private float attackRange;
        [SerializeField] private float attackSpeed;
        [SerializeField] private float chaseRange;
        [SerializeField] private float deathTime;
        [SerializeField] private float attackCooldown;
        [SerializeField] private GameObject bulletPrefab;
        
        public int Health => health;
        public float Speed => speed;
        public float AttackDamage => attackDamage;
        public float AttackRange => attackRange;
        public float AttackSpeed => attackSpeed;
        public float ChaseRange => chaseRange;
        public float DeathTime => deathTime;
        public float AttackCooldown => attackCooldown;
        public GameObject BulletPrefab => bulletPrefab;
        
        public UnityAction<float> OnHealthChanged;
        public UnityAction OnDeath;
        
    }
}
