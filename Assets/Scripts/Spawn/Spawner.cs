using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : Spawnable
{
    [SerializeField] protected T PrefabSpawnable;
    [SerializeField, Min(1)] private int _size;

    private List<T> _spawnables;
    private int _currentSpawnable;

    public void Initialize()
    {
        _spawnables = new List<T>(_size);
        _currentSpawnable = 0;

        for (int i = 0; i < _size; i++)
            CreateSpawnable();
    }

    public void Reset()
    {
        _currentSpawnable = 0;

        foreach (T spawnable in _spawnables)
        {
            spawnable.Reset();
            spawnable.Off();
        }
    }

    protected virtual void CreateSpawnable()
    {
        T spawnable = Instantiate(PrefabSpawnable);
        spawnable.Off();
        AddSpawnable(spawnable);
    }

    protected T GetSpawnable()
    {
        _currentSpawnable = ++_currentSpawnable % _spawnables.Count;
        _spawnables[_currentSpawnable].LifeTimeFinished += PutSpawnable;
        _spawnables[_currentSpawnable].On();
        return _spawnables[_currentSpawnable];
    }

    protected void AddSpawnable(T spawnable)
    {
        _spawnables.Add(spawnable);
    }

    protected virtual void PutSpawnable(Spawnable spawnable)
    {
        spawnable.LifeTimeFinished -= PutSpawnable;
        spawnable.Off();
    }
}