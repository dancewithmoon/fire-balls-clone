using System;
using UnityEngine;

public interface ITankShooter
{
    event Action Shot;
    void Shoot(Vector3 shootPoint);
}
