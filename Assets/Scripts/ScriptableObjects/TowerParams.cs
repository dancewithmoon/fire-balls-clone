using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Tower Params", order = 1)]
public class TowerParams : ScriptableObject
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Block _block;
    [SerializeField] private List<Color> _colors;

    public float TowerSize => _towerSize;
    public Block Block => _block;
    public IReadOnlyList<Color> Colors => _colors.AsReadOnly();
}
