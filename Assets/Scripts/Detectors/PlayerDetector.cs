using UnityEngine;

public class PlayerDetector : UnitDetector
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            OnUnitDetected(player);
        }
    }
}