using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    private int _score;

    public event Action<int> ScoreChanged;

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }

    private void OnEnable()
    {
        _enemySpawner.EnemyKilled += IncreaseScore;
    }

    private void OnDisable()
    {
        _enemySpawner.EnemyKilled -= IncreaseScore;
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
}