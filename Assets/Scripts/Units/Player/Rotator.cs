using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    public void Reset()
    {
        SetMaxRotation();
    }

    private void Start()
    {
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        RotateByZ();
    }

    public void SetMaxRotation()
    {
        transform.rotation = _maxRotation;
    }

    private void RotateByZ()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}