using System;
using UnityEngine;

namespace Enemy.EnemyFiniteStateMachine
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Transform playerTransform;

        private void Start()
        {
            InitEnemies();
        }
        public void InitEnemies()
        {
            foreach (var spawnPoint in spawnPoints)
            {
                var enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemy.GetComponent<EnemyFiniteStateMachine>().Init(playerTransform);
            }
        }
    }
}
