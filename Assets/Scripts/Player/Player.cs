using General;
using ScriptableObjects;
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public PlayerStats playerStats;
        private Health _playerHealth;
        private void InitializePlayer()
        {
            if (!_playerHealth)
            {
                _playerHealth = GetComponent<Health>();
                _playerHealth.Initialize(playerStats);
            }
            playerStats.onDeath.AddListener(OnDeath);
            playerStats.onHit.AddListener(OnHit);
        }
        private void OnEnable()
        {
            InitializePlayer();
        }
        private void OnDisable()
        {
            playerStats.onDeath.RemoveListener(OnDeath);
            playerStats.onHit.RemoveListener(OnHit);
        }
        public GameObject GetBulletPrefab()
        {
            return playerStats.bulletPrefab;
        }
        private void OnHit()
        {
            print("player hit");
            //feedback
        }
        private void OnDeath()
        {
            print("player death");
            Destroy(gameObject);
        }
    }
}
