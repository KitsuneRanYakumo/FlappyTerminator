using System;
using UnityEngine;

[Serializable]
public class Health
{
    private float _max;
    private float _min;

    public Health(float amount)
    {
        _max = amount;
        Amount = _max;
        _min = 0;
    }

    public event Action<float> AmountChanged;

    public float Amount { get; private set; }

    public void Reset()
    {
        Amount = _max;
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0)
            return;

        Amount = Mathf.MoveTowards(Amount, _min, damage);
        AmountChanged?.Invoke(Amount);
    }
}