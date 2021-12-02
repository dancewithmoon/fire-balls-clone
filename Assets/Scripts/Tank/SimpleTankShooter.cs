using System;
using UnityEngine;

public class SimpleTankShooter : ITankShooter
{
    private readonly IBulletsGetter _bulletsGetter;
    public event Action Shot;

    public SimpleTankShooter(IBulletsGetter bulletsGetter)
    {
        _bulletsGetter = bulletsGetter;
    }

    public void Shoot(Vector3 shootPoint)
    {
        Bullet instance = _bulletsGetter.GetBullet();
        instance.PrepareToStart(shootPoint, Quaternion.identity);
        instance.Fire();
        Shot?.Invoke();
    }
}
