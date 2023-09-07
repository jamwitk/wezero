using General.Bullet;
using Interfaces;
using System;
using Player.FiniteStateMachine.States;
using ScriptableObjects;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using Voodoo.Visual.UI;

namespace Player.FiniteStateMachine
{
    public static class AnimatorStrings
    {
        public const string Idle    = "DynIdle";
        public const string Running = "Running";
        public const string Shooting = "Throw";
    }
    public class PlayerFiniteStateMachine : MonoBehaviour
    {
        [Header("References")]
        public Animator animator;
        public VisualJoystick joystick;
        public EnemyTracker enemyTracker;
        public BulletStats bulletStats;
        private Player _player;
        [Space(10)]
        [Header("Player Shooting")]
        public AnimationClip shootingAnimation;
        public bool canShoot = true;
        private Transform _enemyTarget;
        private IPlayerState _currentState;
        private readonly IdleState     _idleState     = new IdleState();
        private readonly RunningState  _runningState  = new RunningState();
        private readonly ShootingState _shootingState = new ShootingState();
        
        private void Start()
        {
            _player = GetComponent<Player>();
            SetIdleState();
        }

        private void Update()
        {
            _currentState?.Update();
        }
        public void SetEnemyTarget(Transform enemy)
        {
            _enemyTarget = enemy;
        }
        public Transform GetEnemyTarget()
        {
            return _enemyTarget;
        }
        public GameObject GetBullet()
        {
            var bullet = Instantiate(_player.GetBulletPrefab(), transform.position, Quaternion.identity);
            if (bullet.TryGetComponent(out Bullet component))
            {
                component.Init(_enemyTarget, bulletStats);
            }
            return bullet;
        }
        private void SetState(IPlayerState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter(this);
        }

        #region StateSetters

        public void SetIdleState()
        {
            SetState(_idleState);
        }

        public void SetRunningState()
        {
            SetState(_runningState);
        }

        public void SetShootingState()
        {
            SetState(_shootingState);
        }

        #endregion
        public float GetAttackCooldown()
        {
            return _player.playerStats.AttackCooldown;
        }
        public float GetPlayerSpeed()
        {
            return _player.playerStats.Speed;
        }
    }
}
