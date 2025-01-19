using System.Collections;
using UnityEngine;

public class Enemy : Unit, IEndGameObject
{
    [SerializeField] private CameraBoundaryEscapeDetector _escapeDetector;
    [SerializeField] private float _delayShooting;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _escapeDetector.BordersEscaped += OnLifeTimeFinished;
    }

    private void OnDisable()
    {
        _escapeDetector.BordersEscaped -= OnLifeTimeFinished;
    }

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public void StartShooting()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    public void StopShooting()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds wait = new WaitForSeconds(_delayShooting);

        while (enabled)
        {
            Weapon.Shoot();
            yield return wait;
        }
    }
}