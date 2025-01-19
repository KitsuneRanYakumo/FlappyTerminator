using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private TimeIncreaser _timeIncreaser;

    private void OnEnable()
    {
        _player.LifeTimeFinished += EndGame;
        _startScreen.PlayButtonClicked += StartGame;
        _endGameScreen.RestartButtonCliked += StartGame;
        _endGameScreen.MenuButtonCliked += ShowStartScreen;
    }

    private void Start()
    {
        _player.Initialize();
        _enemySpawner.Initialize();
        ShowStartScreen();
    }

    private void OnDisable()
    {
        _player.LifeTimeFinished -= EndGame;
        _startScreen.PlayButtonClicked -= StartGame;
        _endGameScreen.RestartButtonCliked -= StartGame;
        _endGameScreen.MenuButtonCliked -= ShowStartScreen;
    }

    private void ShowStartScreen()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _endGameScreen.Close();
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        _startScreen.Close();
        _endGameScreen.Close();
        _player.On();
        _enemySpawner.StartSpawn();
        _timeIncreaser.StartIncreaseTimeScale();
    }

    private void EndGame(Spawnable spawnable)
    {
        _timeIncreaser.EndIncreaseTimeScale();
        _enemySpawner.StopSpawn();
        _player.Reset();
        _enemySpawner.Reset();
        Time.timeScale = 0;
        _endGameScreen.Open();
        _player.Off();
    }
}