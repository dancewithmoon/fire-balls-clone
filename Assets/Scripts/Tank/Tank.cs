using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootCooldown;

    private readonly float _recoilDistance = 0.3f;
    private ITankShooter _shooter;
    private bool _isInCooldown;

    public void Init(ITankShooter shooter)
    {
        _shooter = shooter;
        _shooter.Shot += OnShot;
    }

    private void OnEnable()
    {
        if(_shooter == null)
        {
            return;
        }
        _shooter.Shot += OnShot;
    }

    public void TryShoot()
    {
        if (_isInCooldown == true)
            return;

        _shooter.Shoot(_shootPoint.position);
    }

    private void OnShot()
    {
        StartCoroutine(WaitForCooldown());
        transform.DOMoveZ(transform.position.z - _recoilDistance, _shootCooldown / 2).SetLoops(2, LoopType.Yoyo);
    }

    private IEnumerator WaitForCooldown()
    {
        _isInCooldown = true;
        yield return new WaitForSeconds(_shootCooldown);
        _isInCooldown = false;
    }

    private void OnDisable()
    {
        _shooter.Shot -= OnShot;
    }
}
