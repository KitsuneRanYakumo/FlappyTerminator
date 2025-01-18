using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] private KeyCode _shotButton = KeyCode.Z;
    [SerializeField] private KeyCode _flightButton = KeyCode.Space;

    public bool IsShotButtonPressed => Input.GetKeyDown(_shotButton);

    public bool IsFlightButtonPressed => Input.GetKeyDown(_flightButton);
}