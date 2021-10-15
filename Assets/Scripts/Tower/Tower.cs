using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
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

        foreach (Block block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - broken.GetRealHeigth(), block.transform.position.z);
        }
    }

}
