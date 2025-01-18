using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rigidbody2D;
    private Vector3 _startPosition;

    public void Reset()
    {
        transform.position = _startPosition;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(_moveSpeed, _rigidbody2D.velocity.y);
    }

    public void Move()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _tapForce);
    }
}