using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeSpawner _pipeSpawner;
    [SerializeField] private StartPanelScreen _startPanelScreen;
    [SerializeField] private GameOverPanelScreen _gameOverPanelScreen;

    private void Start()
    {
        _startPanelScreen.Open();
    }

    private void OnEnable()
    {
        _startPanelScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverPanelScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startPanelScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverPanelScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void OnPlayButtonClick()
    {
        _startPanelScreen.Exit();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverPanelScreen.Exit();
        _pipeSpawner.ResetPool();
        StartGame();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverPanelScreen.Open();
    }
    
    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.ResetPlayer();
    }
}
