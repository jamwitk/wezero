using Interfaces;

namespace Enemy.EnemyFiniteStateMachine.EnemyStates
{
    public class EnemyDeath : IEnemyState
    {
        private EnemyFiniteStateMachine _enemy;
        public void Enter(EnemyFiniteStateMachine enemyFiniteStateMachine)
        {
            _enemy = enemyFiniteStateMachine;
            //_enemy.animator.SetTrigger(EnemyAnimationStrings.Death);
        }
        public void Update()
        {
            //death animation?
            
        }
        public void Exit()
        {
        }
    }
}
