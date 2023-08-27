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
        }

        public void Update()
        {
            //search for nearby enemies
            //if there are any, set shooting state
            //else set running state
            if(_player.joystick.GetJoystickDirection() != Vector2.zero)
                _player.SetRunningState();
        }

        public void Exit()
        {
        }
    }
}
