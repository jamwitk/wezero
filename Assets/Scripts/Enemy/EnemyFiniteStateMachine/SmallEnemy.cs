using System;
using UnityEngine;

namespace Enemy.EnemyFiniteStateMachine
{
    public class SmallEnemy : MonoBehaviour
    {
        private EnemyHealth _enemyHealth;
        private void OnEnable()
        {
            _enemyHealth = GetComponent<EnemyHealth>();
            _enemyHealth.enemyStats.onHit.AddListener(OnGetHit);
            _enemyHealth.enemyStats.onDeath.AddListener(OnGetHit);
            _enemyHealth.enemyStats.onDeath.AddListener(OnDie);
        }
        private void OnDisable()
        {
            _enemyHealth.enemyStats.onHit.RemoveListener(OnGetHit);
            _enemyHealth.enemyStats.onDeath.RemoveListener(OnGetHit);
            _enemyHealth.enemyStats.onDeath.RemoveListener(OnDie);
        }
        private void OnDie()
        {
            Destroy(gameObject);
        }
        private void OnGetHit()
        {
            print("enemy hitted " + _enemyHealth.currentHealth + " health left");
        }
    }
}
