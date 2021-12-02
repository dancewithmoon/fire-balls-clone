using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _direction;
    private IEnumerator _movement;

    public void PrepareToStart(Vector3 spawnPoint, Quaternion rotation)
    {
        transform.position = spawnPoint;
        transform.rotation = rotation;
    }

    public void Fire()
    {
        _direction = Vector3.forward;
        gameObject.SetActive(true);
        RestartMovement();
    }

    private void RestartMovement()
    {
        if(_movement != null)
        {
            StopCoroutine(_movement);
        }

        _movement = MoveByDirection();
        StartCoroutine(_movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            Bounce();
        }
        if (other.TryGetComponent(out Block block))
        {
            Hit(block);
        }
    }

    private void Hit(Block block)
    {
        block.Break();
        gameObject.SetActive(false);
    }

    private void Bounce()
    {
        _direction = Vector3.back + Vector3.up;
        RestartMovement();
    }

    private IEnumerator MoveByDirection()
    {
        while (true)
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
            yield return null;
        }
    }
}
