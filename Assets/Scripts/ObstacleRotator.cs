using DG.Tweening;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private float _rotationDuration;

    private void Awake()
    {
        transform.DORotate(new Vector3(0, 360, 0), _rotationDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }
}
