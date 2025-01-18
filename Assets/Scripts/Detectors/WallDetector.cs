using System;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    public event Action FacedWithWall;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Wall>() != null)
        {
            FacedWithWall?.Invoke();
        }
    }
}