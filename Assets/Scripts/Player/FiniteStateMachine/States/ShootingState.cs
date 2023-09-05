using Interfaces;
using System.Collections;
using UnityEngine;

namespace Player.FiniteStateMachine.States
{
    public class ShootingState : IPlayerState
    {
        private PlayerFiniteStateMachine _player;
        private Transform _target;
        
        public void Enter(PlayerFiniteStateMachine playerFiniteStateMachine)
        {
            _player = playerFiniteStateMachine;
            playerFiniteStateMachine.animator.SetTrigger(AnimatorStrings.Idle);
            _target = _player.GetEnemyTarget();
        }

        public void Update()
        {
            if (ReferenceEquals(_target, null))
            {
                _target = _player.enemyTracker.GetNearbyEnemy(_player.transform.position);
                if (ReferenceEquals(_target, null))
                {
                    _player.SetIdleState();
                    return;
                }
            }
            else
            {
                _player.transform.LookAt(_target);
                _player.transform.rotation = Quaternion.Euler(0, _player.transform.rotation.eulerAngles.y, 0);
            }
            if(_player.joystick.IsTouching())
            {
                _player.SetRunningState();
                return;
            }
            Attack();
        }
        private void Attack()
        {
            if (_player.canShoot)
            {
                _player.canShoot = false;
                _player.StartCoroutine(Shoot());
            }
        }
        private IEnumerator Shoot()
        {
            var bullet = _player.GetBullet();
            bullet.SetActive(true);
            yield return new WaitForSeconds(_player.GetAttackCooldown());
            _player.canShoot = true;
        }
        public void Exit()
        {
        }
    }
}
