using UnityEngine;

namespace Interfaces
{
    public interface IHittable
    {
        void GetHit(int damage, GameObject sender);
    }
}
