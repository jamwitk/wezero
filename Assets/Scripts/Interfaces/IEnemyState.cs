using Enemy.EnemyFiniteStateMachine;

namespace Interfaces
{
    public interface IEnemyState
    {
        void Enter(EnemyFiniteStateMachine enemyFiniteStateMachine);
        void Update();
        void Exit();
    }
}
