using Interfaces;
using UnityEngine;

namespace Player.FiniteStateMachine.States
{
    public class IdleState : IPlayerState
    {
        private PlayerFiniteStateMachine _player;
        
        
        public void Enter(PlayerFiniteStateMachine playerFiniteStateMachine)
        {
            _player = playerFiniteStateMachine;
            playerFiniteStateMachine.animator.SetTrigger(AnimatorStrings.Idle);
            var enemy = _player.enemyTracker.GetNearbyEnemy(_player.transform.position);
            _player.SetEnemyTarget(enemy);
        }

        public void Update()
        {
            //search for nearby enemies
            //if there are any, set shooting state
            //else set running state
            if (_player.GetEnemyTarget())
                _player.SetShootingState();
            
            if(_player.joystick.IsTouching())
                _player.SetRunningState();
        }

        public void Exit()
        {
        }
    }
}
