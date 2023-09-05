using Managers;
using ScriptableObjects.Events;
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
        private void FollowPlayer()
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 position = transform.position;
            var smoothedPosition = Vector3.Lerp(position, desiredPosition, smoothSpeed);
            position = new Vector3(position.x, position.y, smoothedPosition.z);
            transform.position = position;
        }
        private void LateUpdate()
        {
            if (GameManager.Instance.CurrentGameState == GameState.InGame)
            {
                FollowPlayer();
            }
        }
    }
}
