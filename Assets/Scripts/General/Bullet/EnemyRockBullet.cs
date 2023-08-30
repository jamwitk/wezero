using ScriptableObjects;
using System;
using UnityEngine;

namespace General.Bullet
{
    
    public class EnemyRockBullet : Bullet
    {
        private Vector3 _targetPosition;
        private void Start()
        {
            _targetPosition = TargetTransform.position;
        }
        private void Update()
        {
            if (!IsInitialized) return;
            if (IsDestroyed) return;
            if (TimeToLiveTimer >= TimeToLive)
            {
                Destroy(gameObject);
                IsDestroyed = true;
                return;
            }
            TimeToLiveTimer += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Speed * Time.deltaTime);
            if (transform.position == _targetPosition)
            {
                Destroy(gameObject);
                IsDestroyed = true;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                print("player hit");
                Destroy(gameObject);
                IsDestroyed = true;
            }
        }
    }
}
