using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    [SerializeField] private float moveDownSpeed = 0.1f;
    private TowerBuilder _builder;
    private List<Block> _blocks;

    private void Awake()
    {
        _builder = GetComponent<TowerBuilder>();
        _blocks = _builder.Build();
        foreach (Block block in _blocks)
        {
            block.Broken += OnBlockBroken;
        }
    }

    private void OnBlockBroken(Block broken)
    {
        broken.Broken -= OnBlockBroken;
        _blocks.Remove(broken);
        _blocks.ForEach((block) => block.MoveDown(broken.GetRealHeigth(), moveDownSpeed));
    }
}
