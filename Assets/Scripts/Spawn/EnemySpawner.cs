using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] private float _spawnFrequency = 3;
    [SerializeField] private float _upperPointSpawn = 5;
    [SerializeField] private float _lowerPointSpawn = -5;

    private bool _isActive;

    public override void Initialize()
    {
        base.Initialize();
        _isActive = true;
    }

    private void OnValidate()
    {
        if (_upperPointSpawn < _lowerPointSpawn)
            _upperPointSpawn = _lowerPointSpawn;
    }

    public override void Reset()
    {
        base.Reset();
        _isActive = true;
    }

    public void StartSpawn()
    {
        StartCoroutine(StartSpawnEnemies());
    }

    private IEnumerator StartSpawnEnemies()
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(_spawnFrequency);

        while (_isActive)
        {
            Enemy enemy = (Enemy)Pool.GetSpawnable();
            enemy.Initialize(GenerateSpawnPosition());
            enemy.StartShooting();
            yield return wait;
        }
    }

    private Vector2 GenerateSpawnPosition()
    {
        return new Vector2(transform.position.x, Random.Range(_lowerPointSpawn, _upperPointSpawn));
    }
}