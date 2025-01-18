using System.Collections;
using UnityEngine;

public class Bullet : Spawnable
{
    [SerializeField] private UnitDetector _unitDetector;
    [SerializeField] private WallDetector _wallDetector;
    [SerializeField] private float _damage = 30;

    private Vector3 _direction;
    private float _moveSpeed;
    private bool _isMoving;

    public void Initialize(Vector3 position, Vector3 direction, float moveSpeed)
    {
        transform.position = position;
        _direction = direction;
        _moveSpeed = moveSpeed;
        _isMoving = true;
        StartCoroutine(MoveTowards());
    }

    private void OnEnable()
    {
        _unitDetector.UnitDetected += Attack;
        _wallDetector.FacedWithWall += OnLifeTimeFinished;
    }

    private void OnDisable()
    {
        _unitDetector.UnitDetected -= Attack;
        _wallDetector.FacedWithWall -= OnLifeTimeFinished;
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