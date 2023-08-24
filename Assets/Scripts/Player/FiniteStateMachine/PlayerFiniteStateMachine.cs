using System;
using Player.FiniteStateMachine.States;
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
        [Space(10)]
        [Header("Player Movement")]
        public float speed = 5f;
        
        
        
        private IPlayerState _currentState;
        private readonly IdleState     _idleState     = new IdleState();
        private readonly RunningState  _runningState  = new RunningState();
        private readonly ShootingState _shootingState = new ShootingState();
        
        private void Start()
        {
            SetIdleState();
        }

        private void Update()
        {
            _currentState?.Update();
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
    }

    public interface IPlayerState
    {
        void Enter(PlayerFiniteStateMachine playerFiniteStateMachine);
        void Update();
        void Exit();
    }
}
