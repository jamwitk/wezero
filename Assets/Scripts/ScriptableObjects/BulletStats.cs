using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletStats", menuName = "ScriptableObjects/BulletStats", order = 1)]
    public class BulletStats : ScriptableObject
    {
        public int Damage;
        public float Speed;
        public float Range;
        public float TimeToLive;
        
    }
}
