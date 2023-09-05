using ScriptableObjects.Events;
using System;
using Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public enum GameState
    {
        MainMenu,
        InGame,
        Paused,
        GameOver
    }
    public class GameManager : Singleton<GameManager>
    {
        public GameState CurrentGameState { get; private set; }
        public GameEvents gameEvents;
        private void Start()
        {
            StartGame();
        }
        private void StartGame()
        {
            CurrentGameState = GameState.InGame;
            gameEvents.onGameStart?.Invoke();
        }
        public void GameOver()
        {
            CurrentGameState = GameState.GameOver;
            gameEvents.onGameOver?.Invoke();
        }
        public void RestartGame()
        {
            CurrentGameState = GameState.InGame;
            gameEvents.onGameRestart?.Invoke();
        }
        public void PauseGame()
        {
            CurrentGameState = GameState.Paused;
            gameEvents.onGamePause?.Invoke();
        }
        public void ResumeGame()
        {
            CurrentGameState = GameState.InGame;
            gameEvents.onGameResume?.Invoke();
        }
        public void QuitGame()
        {
            CurrentGameState = GameState.MainMenu;
            gameEvents.onGameQuit?.Invoke();
        }
    }
}