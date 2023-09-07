using Player;
using ScriptableObjects.Events;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.EnemyFiniteStateMachine
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private GameEvents gameEvents;
        

        private void OnEnable()
        {
            gameEvents.onGameStart.AddListener(InitEnemies);
        }
        private void OnDisable()
        {
            gameEvents.onGameStart.RemoveListener(InitEnemies);
        }
        
        private void InitEnemies()
        {
            foreach (var spawnPoint in spawnPoints)
            {
                var enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemy.GetComponent<EnemyFiniteStateMachine>().Init(playerTransform);
            }
        }
    }
}
