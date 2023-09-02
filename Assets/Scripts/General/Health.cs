using Interfaces;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace General
{
    public class Health : MonoBehaviour, IHittable
    {
        private int _currentHealth;
        private PlayerStats _playerStats;
        public void GetHit(int damage, GameObject sender)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                print("player death");
                _playerStats.onDeath?.Invoke();
            }
            else
            {
                _playerStats.onHit?.Invoke();
                print("player hit "+_currentHealth+" health left");

            }
        }
        public void Initialize(PlayerStats myStats)
        {
            _playerStats = myStats;
            _currentHealth = (int)_playerStats.Health;
        }
    }
}
