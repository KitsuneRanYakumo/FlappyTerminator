using System;
using UnityEngine;

public class UnitDetector : MonoBehaviour
{
    public event Action<Unit> UnitDetected;

    protected void OnUnitDetected(Unit unit)
    {
        UnitDetected?.Invoke(unit);
    }
}