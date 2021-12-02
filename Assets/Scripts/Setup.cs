using UnityEngine;

public class Setup : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private PointerDownHandlerImpl _input;

    [Header("Tank")]
    [SerializeField] private Tank _tank;
    [SerializeField] private Bullet _bulletPrefab;

    [Header("Tower")]
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private TowerParams _towerParams;
    [SerializeField] private TowerHeightView _towerHeightView;

    private Tower _tower;

    private void Awake()
    {
        _tank.Init(new SimpleTankShooter(new BulletsPool(_bulletPrefab, 10)));
        var towerBuilder = new TowerBuilder(_buildPoint, _towerParams);
        _tower = towerBuilder.Build();
        _towerHeightView.OnHeightUpdated(_tower.Height);
    }

    private void OnEnable()
    {
        _input.PointerDown += _tank.TryShoot;
        _tower.HeightUpdated += _towerHeightView.OnHeightUpdated;
    }

    private void OnDisable()
    {
        _input.PointerDown -= _tank.TryShoot;
        _tower.HeightUpdated -= _towerHeightView.OnHeightUpdated;
    }
}
