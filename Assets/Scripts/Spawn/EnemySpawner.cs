using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private float _spawnFrequency = 3;
    [SerializeField] private float _upperPointSpawn = 5;
    [SerializeField] private float _lowerPointSpawn = -5;

    private Coroutine _coroutine;

    public event Action EnemyKilled;

    private void OnValidate()
    {
        if (_upperPointSpawn < _lowerPointSpawn)
            _upperPointSpawn = _lowerPointSpawn;
    }

    public void StartSpawn()
    {
        _coroutine = StartCoroutine(StartSpawnEnemies());
    }

    public void StopSpawn()
    {
        if ( _coroutine != null )
            StopCoroutine(_coroutine);
    }

    protected override void CreateSpawnable()
    {
        Enemy enemy = Instantiate(PrefabSpawnable);
        enemy.Initialize();
        enemy.Off();
        AddSpawnable(enemy);
    }

    protected override void PutSpawnable(Spawnable spawnable)
    {
        base.PutSpawnable(spawnable);
        Enemy enemy = (Enemy)spawnable;
        enemy.Reset();
        enemy.HealthWasted -= OnEnemyKilled;
    }

    private IEnumerator StartSpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnFrequency);

        while (enabled)
        {
            Enemy enemy = GetSpawnable();
            enemy.HealthWasted += OnEnemyKilled;
            enemy.SetPosition(GenerateSpawnPosition());
            enemy.StartShooting();
            yield return wait;
        }
    }

    private Vector2 GenerateSpawnPosition()
    {
        return new Vector2(transform.position.x, Random.Range(_lowerPointSpawn, _upperPointSpawn));
    }

    private void OnEnemyKilled()
    {
        EnemyKilled?.Invoke();
    }
}