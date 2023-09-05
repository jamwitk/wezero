using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "GameEvents", menuName = "ScriptableObjects/Events/GameEvents")]
    public class GameEvents : ScriptableObject
    {
        public UnityEvent onGameStart;
        public UnityEvent onGameOver;
        public UnityEvent onGameRestart;
        public UnityEvent onGamePause;
        public UnityEvent onGameResume;
        public UnityEvent onGameQuit;
    }
}
