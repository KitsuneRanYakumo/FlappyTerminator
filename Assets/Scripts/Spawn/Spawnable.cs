using System;
using UnityEngine;

public abstract class Spawnable : MonoBehaviour
{
    public event Action<Spawnable> LifeTimeFinished;

    public virtual void Reset() { }

    protected void OnLifeTimeFinished()
    {
        LifeTimeFinished?.Invoke(this);
    }
}