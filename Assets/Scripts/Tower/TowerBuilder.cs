using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder
{
    private Transform _buildPoint;
    private TowerParams _towerParams;
    private float _blockHeight = 0;

    public TowerBuilder(Transform buildPoint, TowerParams towerParams)
    {
        _buildPoint = buildPoint;
        _towerParams = towerParams;
        _blockHeight = _towerParams.Block.RealHeight;
    }

    public Tower Build()
    {
        List<Block> blocks = new List<Block>();
        Transform currentPoint = _buildPoint;

        for (int i = 0; i < _towerParams.TowerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            newBlock.SetColor(_towerParams.Colors[Random.Range(0, _towerParams.Colors.Count)]);
            blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }
        var tower = new GameObject().AddComponent<Tower>();
        tower.Init(blocks);
        return tower;
    }

    private Block BuildBlock(Transform currentBuildPoint)
    {
        return Object.Instantiate(_towerParams.Block, GetBuildPoint(currentBuildPoint), Quaternion.identity, _buildPoint);
    }

    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        var currentMeshFilter = currentSegment.GetComponentInChildren<MeshFilter>();
        float currentSegmentHeight = 0;
        if (currentMeshFilter != null)
        {
            currentSegmentHeight = currentMeshFilter.GetRealHeight();
        }

        return new Vector3(_towerParams.Block.transform.position.x, currentSegment.position.y + currentSegmentHeight / 2 + _blockHeight / 2, _towerParams.Block.transform.position.z);
    }
}
