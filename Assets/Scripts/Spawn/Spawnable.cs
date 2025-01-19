using System;
using UnityEngine;

public abstract class Spawnable : MonoBehaviour 
{
    public event Action<Spawnable> LifeTimeFinished;

    public abstract void Reset();

    public void On()
    {
        gameObject.SetActive(true);
    }

    public void Off()
    {
        gameObject.SetActive(false);
    }

    protected void OnLifeTimeFinished()
    {
        LifeTimeFinished?.Invoke(this);
    }
}