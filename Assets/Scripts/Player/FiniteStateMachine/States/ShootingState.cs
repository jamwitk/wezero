using UnityEngine;

namespace Player.FiniteStateMachine.States
{
    public class ShootingState : IPlayerState
    {
        private PlayerFiniteStateMachine _player;
        private Transform                _target;
        public void Enter(PlayerFiniteStateMachine playerFiniteStateMachine)
        {
            _player = playerFiniteStateMachine;
            playerFiniteStateMachine.animator.SetTrigger(AnimatorStrings.Idle);
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
                //TODO: shoot
            }
        }

        public void Exit()
        {
        }
    }
}
