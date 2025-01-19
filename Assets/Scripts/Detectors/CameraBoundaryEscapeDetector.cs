using System;
using UnityEngine;

public class CameraBoundaryEscapeDetector : MonoBehaviour
{
    public event Action BordersEscaped;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<CameraBoundaries>() != null)
        {
            BordersEscaped?.Invoke();
        }
    }
}
