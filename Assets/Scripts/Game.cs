using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

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
        _endGameScreen.Close();
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
        _player.gameObject.SetActive(true);
        _enemySpawner.StartSpawn();
    }

    private void EndGame(Spawnable spawnable)
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
        _player.Reset();
        _enemySpawner.Reset();
        _player.gameObject.SetActive(false);
    }
}