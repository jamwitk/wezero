using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class EnemyTracker : MonoBehaviour
    {
        [SerializeField] private List<GameObject> enemies = new List<GameObject>();

        private void Start()
        {
            Init();
        }
        private void Init()
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        }
        
        public Transform GetNearbyEnemy(Vector3 playerPosition)
        {
            Transform closestEnemy = null;
            float closestDistance = Mathf.Infinity;
            foreach (var enemy in enemies)
            {
                if (!enemy)
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
