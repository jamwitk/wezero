using General;
using ScriptableObjects;
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public PlayerStats stats;
        private Health _playerHealth;
        private void InitializePlayer()
        {
            if (!_playerHealth)
            {
                _playerHealth = GetComponent<Health>();
                _playerHealth.Initialize(stats);
            }
            stats.onDeath.AddListener(OnDeath);
            stats.onHit.AddListener(OnHit);
        }
        private void OnEnable()
        {
            InitializePlayer();
        }
        private void OnDisable()
        {
            stats.onDeath.RemoveListener(OnDeath);
            stats.onHit.RemoveListener(OnHit);
        }
        public GameObject GetBulletPrefab()
        {
            return stats.bulletPrefab;
        }
        private void OnHit()
        {
            print("player hit");
        }
        private void OnDeath()
        {
            print("player death");
            Destroy(gameObject);
        }
    }
}
