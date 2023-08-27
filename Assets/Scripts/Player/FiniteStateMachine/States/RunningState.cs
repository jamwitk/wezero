using UnityEngine;

namespace Player.FiniteStateMachine.States
{
    public class RunningState : IPlayerState
    {
        private PlayerFiniteStateMachine _player;
        public void Enter(PlayerFiniteStateMachine playerFiniteStateMachine)
        {
            _player = playerFiniteStateMachine;
            playerFiniteStateMachine.animator.SetTrigger(AnimatorStrings.Running);
        }

        public void Update()
        {
            if (_player.joystick.GetJoystickDirection() == Vector2.zero)
            {
                _player.SetIdleState();
                return;                
            }
           
            MoveAndRotate();
        }
        
        private void MoveAndRotate()
        {
            
            _player.transform.position += new Vector3(_player.joystick.GetJoystickDirection().x,0,_player.joystick.GetJoystickDirection().y) * (_player.speed * Time.deltaTime);
            
            _player.transform.rotation = Quaternion.Euler(0, Mathf.Atan2(_player.joystick.GetJoystickDirection().x, _player.joystick.GetJoystickDirection().y) * Mathf.Rad2Deg,0);

        }
        public void Exit()
        {
        }
    }
}
