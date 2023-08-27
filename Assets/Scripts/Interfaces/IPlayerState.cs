using Player.FiniteStateMachine;

namespace Interfaces
{
    public interface IPlayerState
    {
        void Enter(PlayerFiniteStateMachine playerFiniteStateMachine);
        void Update();
        void Exit();
    }
}
