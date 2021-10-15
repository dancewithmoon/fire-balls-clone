using System.Collections.Generic;
using UnityEngine;

public class BulletsPool
{
    private readonly int _maxPoolSize = 10;
    private readonly Queue<Bullet> _bulletsPool = new Queue<Bullet>();
    private readonly Transform _bulletsParent;

    private Bullet _bullet;

    public BulletsPool(Bullet bullet)
    {
        _bulletsParent = new GameObject("Bullets").transform;
        _bullet = bullet;
    }

    public Bullet GetBullet()
    {
        Bullet bullet;
        if (_bulletsPool.Count < _maxPoolSize)
        {
            bullet = Object.Instantiate(_bullet, _bulletsParent);
        }
        else
        {
            bullet = _bulletsPool.Dequeue();
        }

        _bulletsPool.Enqueue(bullet);
       
        return bullet;
    }
}

