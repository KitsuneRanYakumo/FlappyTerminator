using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected Pool Pool;

    public virtual void Initialize()
    {
        Pool.Initialize();
    }

    public virtual void Reset()
    {
        Pool.Reset();
    }
}