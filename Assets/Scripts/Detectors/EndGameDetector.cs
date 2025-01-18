using System;
using UnityEngine;

public class EndGameDetector : MonoBehaviour
{
    public event Action FacedWithEndGameObject;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<IEndGameObject>() != null)
        {
            FacedWithEndGameObject?.Invoke();
        }
    }
}