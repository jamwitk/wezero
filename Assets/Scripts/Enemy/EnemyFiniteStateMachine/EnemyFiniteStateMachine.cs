using Enemy.EnemyFiniteStateMachine.EnemyStates;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Enemy.EnemyFiniteStateMachine
{
    public class EnemyFiniteStateMachine : MonoBehaviour
    {
        [SerializeField] private EnemyIdle _enemyIdle = new EnemyIdle();
        [SerializeField] private EnemyChase _enemyChase = new EnemyChase();
        [SerializeField] private EnemyAttack _enemyAttack = new EnemyAttack();
        [SerializeField] private EnemyDeath _enemyDeath = new EnemyDeath();
        private IEnemyState _currentState;
        [SerializeField] private EnemyStats enemyStats;
        
        public Transform playerTransform;
        public bool canShoot = true;

        private void Start()
        {
            SetEnemyIdle();
        }
        public void Init(Transform player)
        {
            playerTransform = player;
        }
        
        private void Update()
        {
            _currentState.Update();
        }
        private void ChangeState(IEnemyState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter(this);
        }
        
        public void SetEnemyIdle()
        {
            ChangeState(_enemyIdle);
            print("enemy idle");
        }
        public void SetEnemyChase()
        {
            ChangeState(_enemyChase);
            print("enemy chase");
        }
        public void SetEnemyAttack()
        {
            ChangeState(_enemyAttack);
            print("enemy attack");
        }
        public void SetEnemyDeath()
        {
            ChangeState(_enemyDeath);
            print("enemy death");
        }
        
        #region Getters

        public int GetHealth()
        {
            return enemyStats.Health;
        }
        public int GetDamage()
        {
            return enemyStats.AttackDamage;
        }
        public float GetAttackRange()
        {
            return enemyStats.AttackRange;
        }
        public GameObject GetBullet()
        {
            return Instantiate(enemyStats.BulletPrefab);
        }
        public float GetChaseRange()
        {
            return enemyStats.ChaseRange;
        }
        public float GetMovementSpeed()
        {
            return enemyStats.Speed;
        }
        public float GetAttackSpeed()
        {
            return enemyStats.AttackSpeed;
        }
        public float GetAttackCooldown()
        {
            return enemyStats.AttackCooldown;
        }

        #endregion

        public void SetAttackCooldown(float getAttackCooldown)
        {
            
        }
    }
}
