using Interfaces;
using UnityEngine;

namespace Enemy.EnemyFiniteStateMachine.EnemyStates
{
    public class EnemyChase : IEnemyState
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
                var distance = _enemy.transform.position - _enemy.playerTransform.position;
                if (distance.magnitude > _enemy.GetAttackRange())
                {
                    Chase();
                    return;
                }
                _enemy.SetEnemyAttack();
            }
            else
            {
                _enemy.SetEnemyIdle();
            }
        }
        private void Chase()
        {
            //use navmesh to move towards player
            _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _enemy.playerTransform.position, _enemy.GetMovementSpeed() * Time.deltaTime);
        }
        public void Exit()
        {
        }
    }
}
