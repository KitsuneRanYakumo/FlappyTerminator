using System.Collections;
using UnityEngine;

[RequireComponent(typeof(UnitDetector), typeof(CameraBoundaryEscapeDetector))]
public class Bullet : Spawnable
{
    [SerializeField] private float _damage = 30;

    private UnitDetector _unitDetector;
    private CameraBoundaryEscapeDetector _escapeDetector;
    private Coroutine _coroutine;
    private Vector3 _direction;
    private float _moveSpeed;
    private bool _isMoving;

    public void Initialize(Vector3 position, Vector3 direction, float moveSpeed)
    {
        transform.position = position;
        _direction = direction;
        _moveSpeed = moveSpeed;
        _isMoving = true;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(MoveTowards());
    }

    public override void Reset()
    {
        _isMoving = false;
    }

    private void Awake()
    {
        _unitDetector = GetComponent<UnitDetector>();
        _escapeDetector = GetComponent<CameraBoundaryEscapeDetector>();
    }

    private void OnEnable()
    {
        _unitDetector.UnitDetected += Attack;
        _escapeDetector.BordersEscaped += OnLifeTimeFinished;
    }

    private void OnDisable()
    {
        _unitDetector.UnitDetected -= Attack;
        _escapeDetector.BordersEscaped -= OnLifeTimeFinished;
    }

    private IEnumerator MoveTowards()
    {
        while (_isMoving)
        {
            transform.Translate(_moveSpeed * Time.deltaTime * _direction);
            yield return null;
        }
    }

    private void Attack(IDamageble damageble)
    {
        damageble.TakeDamage(_damage);
        _isMoving = false;
        OnLifeTimeFinished();
    }
}