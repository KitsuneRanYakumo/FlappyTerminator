using UnityEngine;

public class EnemyDetector : UnitDetector
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
        {
            OnUnitDetected(enemy);
        }
    }
}