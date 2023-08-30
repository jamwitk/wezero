using Interfaces;
using System.Collections;
using UnityEngine;

namespace Enemy.EnemyFiniteStateMachine.EnemyStates
{
    public class EnemyAttack : IEnemyState
    {
        private EnemyFiniteStateMachine _enemy;
        public void Enter(EnemyFiniteStateMachine enemyFiniteStateMachine)
        {
            _enemy = enemyFiniteStateMachine;
            _enemy.animator.SetTrigger(EnemyAnimationStrings.Attack);
        }
        public void Update()
        {
            if (_enemy.playerTransform)
            {
                var distance = _enemy.transform.position - _enemy.playerTransform.position;
                if (distance.magnitude > _enemy.GetAttackRange())
                {
                    _enemy.SetEnemyChase();
                    return;
                }
                Attack();
            }
        }
        private void Attack()
        {
            if (_enemy.canShoot)
            {
                _enemy.canShoot = false;
                _enemy.StartCoroutine(Shoot());
            }
            _enemy.transform.LookAt(_enemy.playerTransform);
        }
        private IEnumerator Shoot()
        {
            var bullet = _enemy.GetBullet();
            bullet.transform.position = _enemy.transform.position;
            bullet.transform.rotation = _enemy.transform.rotation;
            bullet.SetActive(true);
            yield return new WaitForSeconds(_enemy.GetAttackCooldown());
            _enemy.canShoot = true;
        }
        
        public void Exit()
        {
        }
    }
}
