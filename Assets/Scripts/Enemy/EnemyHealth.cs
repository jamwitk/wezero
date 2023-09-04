using General;
using Interfaces;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IHittable
    {
        public  int currentHealth;
        [FormerlySerializedAs("_enemyStats")]
        public  EnemyStats enemyStats;
        public void GetHit(int damage, GameObject sender)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                enemyStats.onDeath?.Invoke();
            }
            else
            {
                enemyStats.onHit?.Invoke();

            }
        }
        public void Initialize(EnemyStats myStats)
        {
            enemyStats = myStats;
            currentHealth = enemyStats.Health;
        }
    }
}
