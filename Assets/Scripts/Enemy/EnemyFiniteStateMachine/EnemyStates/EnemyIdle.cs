﻿using Interfaces;
using UnityEngine;

namespace Enemy.EnemyFiniteStateMachine.EnemyStates
{
    public class EnemyIdle : IEnemyState
    {
        private EnemyFiniteStateMachine _enemy;
        public void Enter(EnemyFiniteStateMachine enemyFiniteStateMachine)
        {
            _enemy = enemyFiniteStateMachine;
        }
        public void Update()
        {
            if (_enemy.playerTransform)
            {
                _enemy.SetEnemyChase();
                return;
            }
            
        }
        public void Exit()
        {
        }
    }
}
