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
        
        public float Speed => speed;
        public float Health
        {
            get
            {
                return health;
            }
            set
            {
                health = Math.Max(value, 0);
                OnHealthChanged?.Invoke(health);
            }
        }
        
        public UnityAction<float> OnHealthChanged;
        
    }
}
