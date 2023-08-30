using Interfaces;
using UnityEngine;

namespace Enemy.EnemyFiniteStateMachine.EnemyStates
{
    public class EnemyIdle : IEnemyState
    {
        private EnemyFiniteStateMachine _enemy;
        public void Enter(EnemyFiniteStateMachine enemyFiniteStateMachine)
        {
            _enemy = enemyFiniteStateMachine;
            _enemy.animator.SetTrigger(EnemyAnimationStrings.Idle);
        }
        public void Update()
        {
            if (_enemy.playerTransform)
            {
                _enemy.SetEnemyChase();
                return;
            }
            //patrol?
            
        }
        public void Exit()
        {
            _enemy.animator.ResetTrigger(EnemyAnimationStrings.Idle);
        }
    }
}
