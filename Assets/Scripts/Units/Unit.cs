using System;
using UnityEngine;

public abstract class Unit : Spawnable, IDamageble
{
    [SerializeField] protected Weapon Weapon;
    [SerializeField] private float _amountHealth;

    public Health Health { get; private set; }

    public event Action DamageTaken;
    public event Action HealthWasted;

    public void Initialize()
    {
        Health = new Health(_amountHealth);
        Weapon.Initialize();
    }

    public override void Reset()
    {
        Health.Reset();
        Weapon.Reset();
    }

    public void TakeDamage(float damage)
    {
        Health.TakeDamage(damage);
        DamageTaken?.Invoke();

        if (Health.Amount <= 0)
        {
            HealthWasted?.Invoke();
            OnLifeTimeFinished();
        }
    }
}