using System;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private readonly float moveDownSpeed = 0.1f;
    private List<Block> _blocks;

    public int Height => _blocks.Count;

    public event Action<int> HeightUpdated;

    public void Init(List<Block> blocks)
    {
        _blocks = blocks;
        foreach (Block block in _blocks)
        {
            block.Broken += OnBlockBroken;
        }
    }

    private void OnBlockBroken(Block broken)
    {
        broken.Broken -= OnBlockBroken;
        _blocks.Remove(broken);
        _blocks.ForEach((block) => block.MoveDown(broken.RealHeight, moveDownSpeed));
        HeightUpdated?.Invoke(Height);
    }

    private void OnDestroy()
    {
        foreach (Block block in _blocks)
        {
            block.Broken -= OnBlockBroken;
        }
    }
}
