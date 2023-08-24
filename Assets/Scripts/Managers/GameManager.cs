using UnityEngine;

namespace Managers
{
    public enum GameState
    {
        MainMenu,
        InGame,
        GameOver
    }
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GameState CurrentGameState { get; private set; }
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            SetGameState(GameState.MainMenu);
        }

        private void SetGameState(GameState state)
        {
            CurrentGameState = state;
            switch (state)
            {
                case GameState.MainMenu:
                    break;
                case GameState.InGame:
                    break;
                case GameState.GameOver:
                    break;
                default:
                    break;
            }
        }   
    }
}