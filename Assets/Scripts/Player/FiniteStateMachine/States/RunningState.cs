using Interfaces;
using UnityEngine;

namespace Player.FiniteStateMachine.States
{
    public class RunningState : IPlayerState
    {
        private PlayerFiniteStateMachine _playerFiniteStateMachine;
        private float _speed;
        public void Enter(PlayerFiniteStateMachine playerFiniteStateMachine)
        {
            _playerFiniteStateMachine = playerFiniteStateMachine;
            _speed = _playerFiniteStateMachine.GetPlayerSpeed();
            playerFiniteStateMachine.animator.SetTrigger(AnimatorStrings.Running);
        }

        public void Update()
        {
            if (!_playerFiniteStateMachine.joystick.IsTouching())
            {
                _playerFiniteStateMachine.SetIdleState();
                return;                
            }
           
            MoveAndRotate();
        }
        
        private void MoveAndRotate()
        {
            
            _playerFiniteStateMachine.transform.position += new Vector3(_playerFiniteStateMachine.joystick.GetJoystickDirection().x,0,_playerFiniteStateMachine.joystick.GetJoystickDirection().y) * (_speed * Time.deltaTime);
            
            _playerFiniteStateMachine.transform.rotation = Quaternion.Euler(0, Mathf.Atan2(_playerFiniteStateMachine.joystick.GetJoystickDirection().x, _playerFiniteStateMachine.joystick.GetJoystickDirection().y) * Mathf.Rad2Deg,0);

        }
        public void Exit()
        {
        }
    }
}
