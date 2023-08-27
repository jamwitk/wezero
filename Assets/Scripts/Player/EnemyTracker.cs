using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class EnemyTracker : MonoBehaviour
    {
        [SerializeField] private readonly List<GameObject> _enemies = new List<GameObject>();
        
        public void AddEnemy(GameObject enemy)
        {
            _enemies.Add(enemy);
        }
        
        public Transform GetNearbyEnemy(Vector3 playerPosition)
        {
            Transform closestEnemy = null;
            float closestDistance = Mathf.Infinity;
            foreach (var enemy in _enemies)
            {
                if (enemy == null)
                    continue;
                var distance = Vector3.Distance(playerPosition, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy.transform;
                }
            }
            return closestEnemy;
        }
    }
}
