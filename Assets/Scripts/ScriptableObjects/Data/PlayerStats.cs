using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 1)]
    public class PlayerStats : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private float health;
        [SerializeField] private float damage;
        [SerializeField] private float attackSpeed;
        [SerializeField] private float criticalChance;
        [SerializeField] private float criticalDamage;
        [SerializeField] private float attackCooldown;
        public GameObject bulletPrefab;
        public float Speed => speed;
        public float AttackCooldown => attackCooldown;
        public float Health
        {
            get
            {
                return health;
            }
        }

        public UnityEvent onDeath;
        public UnityEvent onHit;

    }
}
