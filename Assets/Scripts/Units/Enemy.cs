using System.Collections;
using UnityEngine;

public class Enemy : Unit, IEndGameObject
{
    [SerializeField] private WallDetector _wallDetector;
    [SerializeField] private float _delayShooting;

    public void Initialize(Vector2 position)
    {
        transform.position = position;
        base.Initialize();
    }

    private void OnEnable()
    {
        _wallDetector.FacedWithWall += OnLifeTimeFinished;
    }

    private void OnDisable()
    {
        _wallDetector.FacedWithWall -= OnLifeTimeFinished;
    }

    public void StartShooting()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(_delayShooting);

        while (gameObject.activeSelf)
        {
            Weapon.Shoot();
            yield return wait;
        }
    }
}