using Interfaces;
using System.Collections;
using UnityEngine;

namespace Player.FiniteStateMachine.States
{
    public class ShootingState : IPlayerState
    {
        private PlayerFiniteStateMachine _player;
        private Transform _target;
        private float _animationDefaultSpeed = 1f;
        private float _animationDefaultTime = 2.2f;
        
        public void Enter(PlayerFiniteStateMachine playerFiniteStateMachine)
        {
            _player = playerFiniteStateMachine;
            CalculateAnimationSpeed();
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
            _player.animator.SetTrigger(AnimatorStrings.Shooting);
            yield return new WaitForSeconds(_player.GetAttackCooldown());
            _player.canShoot = true;
        }
        private void CalculateAnimationSpeed()
        {
            _animationDefaultSpeed = _player.animator.speed;
            var speed = _animationDefaultTime / _player.GetAttackCooldown();
            _player.animator.speed *= speed;
        }
        public void Exit()
        {
            _player.animator.speed = _animationDefaultSpeed;
        }
    }
}
