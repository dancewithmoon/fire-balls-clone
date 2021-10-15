using System.Collections;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private PointerDownHandlerImpl _input;
    
    [Space(10)]
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _shootCooldown;

    private bool isInCooldown;
    private BulletsPool _bulletsPool;

    private void Awake()
    {
        _bulletsPool = new BulletsPool(_bulletPrefab);
    }

    private void OnEnable()
    {
        _input.PointerDown += TryShoot;
    }

    private void TryShoot()
    {
        if (isInCooldown == true)
            return;

        Shoot();
    }

    private void Shoot()
    {
        Bullet instance = _bulletsPool.GetBullet();
        instance.PrepareToStart(_shootPoint.position, Quaternion.identity);
        instance.Fire();

        StartCoroutine(WaitForCooldown());
    }

    private IEnumerator WaitForCooldown()
    {
        isInCooldown = true;
        yield return new WaitForSeconds(_shootCooldown);
        isInCooldown = false;
    }

    private void OnDisable()
    {
        _input.PointerDown -= TryShoot;
    }
}
