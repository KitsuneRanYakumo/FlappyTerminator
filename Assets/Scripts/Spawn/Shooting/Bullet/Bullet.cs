using UnityEngine;

[RequireComponent(typeof(BulletMover), typeof(UnitDetector), typeof(CameraBoundaryEscapeDetector))]
public class Bullet : Spawnable
{
    [SerializeField] private float _damage = 30;

    private BulletMover _bulletMover;
    private UnitDetector _unitDetector;
    private CameraBoundaryEscapeDetector _escapeDetector;

    public void Initialize(Vector3 position, Vector3 direction, float moveSpeed)
    {
        _bulletMover.Initialize(position, direction, moveSpeed);
    }

    public override void Reset()
    {
        _bulletMover.Reset();
    }

    private void Awake()
    {
        _bulletMover = GetComponent<BulletMover>();
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

    private void Attack(IDamageble damageble)
    {
        damageble.TakeDamage(_damage);
        _bulletMover.StopMoving();
        OnLifeTimeFinished();
    }
}