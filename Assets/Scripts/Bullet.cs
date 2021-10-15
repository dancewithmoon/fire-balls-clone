using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private readonly Vector3 _direction = Vector3.forward;

    public void PrepareToStart(Vector3 spawnPoint, Quaternion rotation)
    {
        transform.position = spawnPoint;
        transform.rotation = rotation;
    }

    public void Fire()
    {
        StopAllCoroutines();
        gameObject.SetActive(true);
        StartCoroutine(MoveByDirection());
    }

    private IEnumerator MoveByDirection()
    {
        while (true)
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var block = other.GetComponentInParent<Block>();
        if (block == null)
            return;

        block.Break();
        gameObject.SetActive(false);
    }
}
