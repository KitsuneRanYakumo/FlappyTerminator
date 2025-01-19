using UnityEngine;

public class Weapon : Spawner<Bullet>
{
    [SerializeField] private Transform _pointShot;
    [SerializeField] private float _shootingPower;

    public void Shoot()
    {
        Bullet bullet = GetSpawnable();
        bullet.Initialize(_pointShot.position, GetDirection(), _shootingPower);
    }

    public Vector2 GetDirection()
    {
        return (_pointShot.position - transform.position).normalized;
    }
}