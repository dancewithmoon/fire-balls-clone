using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TowerHeightView : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    private TMP_Text _height;

    private void Awake()
    {
        _height = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _tower.HeightUpdated += OnHeightUpdated;
    }

    private void Start()
    {
        _height.text = _tower.Height.ToString();
    }

    private void OnHeightUpdated(int height)
    {
        _height.text = height.ToString();
    }

    private void OnDisable()
    {
        _tower.HeightUpdated -= OnHeightUpdated;
    }
}
