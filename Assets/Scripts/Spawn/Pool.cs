using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Spawnable _prefabSpawnable;
    [SerializeField, Min(1)] private int _size;

    private List<Spawnable> _spawnables;
    private int _currentSpawnable;

    public void Initialize()
    {
        _spawnables = new List<Spawnable>(_size);
        _currentSpawnable = 0;

        for (int i = 0; i < _size; i++)
            CreateSpawnable();
    }

    public void Reset()
    {
        _currentSpawnable = 0;

        if (_spawnables.Count > 0)
        {
            foreach (Spawnable spawnable in _spawnables)
            {
                if (spawnable != null)
                {
                    spawnable.Reset();
                    spawnable.gameObject.SetActive(false);
                }
            }
        }
    }

    public Spawnable GetSpawnable()
    {
        _currentSpawnable = ++_currentSpawnable % _spawnables.Count;
        _spawnables[_currentSpawnable].LifeTimeFinished += PutSpawnable;
        _spawnables[_currentSpawnable].gameObject.SetActive(true);
        return _spawnables[_currentSpawnable];
    }

    private void PutSpawnable(Spawnable spawnable)
    {
        spawnable.gameObject.SetActive(false);
        spawnable.LifeTimeFinished -= PutSpawnable;
    }

    private void CreateSpawnable()
    {
        Spawnable spawnable = Instantiate(_prefabSpawnable);
        spawnable.gameObject.SetActive(false);
        _spawnables.Add(spawnable);
    }
}