using System;
using UnityEngine;

namespace General
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Vector3   offset;
        [SerializeField] private float     smoothSpeed = 0.125f;

        private void Start()
        {
            offset = transform.position - player.position;
        }

        private void LateUpdate()
        {
           //follow player only on z axis
           var desiredPosition = player.position + offset;
           var position = transform.position;
           var smoothedPosition = Vector3.Lerp(position, desiredPosition, smoothSpeed);
           position = new Vector3(position.x, position.y, smoothedPosition.z);
           transform.position = position;
        }
    }
}
