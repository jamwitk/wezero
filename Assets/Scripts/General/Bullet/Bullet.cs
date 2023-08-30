using ScriptableObjects;
using System;
using UnityEngine;

namespace General.Bullet
{
    public abstract class Bullet : MonoBehaviour
    {
        public Transform TargetTransform { get; private set; }
        public int Damage { get; private set; }
        public float Speed { get; private set; }
        public float Range { get; private set; }
        public float TimeToLive { get; private set; }
        public float TimeToLiveTimer { get;
            internal set; }
        public bool IsDestroyed { get;
            internal set; }
        public bool IsInitialized { get; private set; }
        
        public void Init(Transform targetTransform, BulletStats bulletStats)
        {
            TargetTransform = targetTransform;
            Damage = bulletStats.Damage;
            Speed = bulletStats.Speed;
            Range = bulletStats.Range;
            TimeToLive = bulletStats.TimeToLive;
            TimeToLiveTimer = 0;
            IsDestroyed = false;
            IsInitialized = true;
        }
    }
}
