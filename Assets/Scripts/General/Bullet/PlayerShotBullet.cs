using Interfaces;
using UnityEngine;

namespace General.Bullet
{
    public class PlayerShotBullet : Bullet
    {
        private void Update()
        {
            if(TargetTransform)
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
                transform.position = Vector3.MoveTowards(transform.position, TargetTransform.position, Speed * Time.deltaTime);
                if (transform.position == TargetTransform.position)
                {
                    Destroy(gameObject);
                    IsDestroyed = true;
                }
            }
            else
            {
                Destroy(gameObject);
                IsDestroyed = true;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (other.transform.root.TryGetComponent(out IHittable target))
                {
                    target.GetHit(Damage, gameObject);
                }
                Destroy(gameObject);
                IsDestroyed = true;
            }
        }
    }
}
