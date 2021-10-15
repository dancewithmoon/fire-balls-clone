using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;
    private float _blockHeigth = 0;

    private void Awake()
    {
        _blockHeigth = _block.GetComponentInChildren<MeshFilter>().GetRealHeigth();
    }

    public List<Block> Build()
    {
        List<Block> blocks = new List<Block>();
        Transform currentPoint = _buildPoint;

        for (int i = 0; i < _towerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }
        return blocks;
    }

    private Block BuildBlock(Transform currentBuildPoint)
    {
        return Instantiate(_block, GetBuildPoint(currentBuildPoint), Quaternion.identity, _buildPoint);
    }

    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        var currentMeshFilter = currentSegment.GetComponentInChildren<MeshFilter>();
        float currentSegmentHeigth = 0;
        if (currentMeshFilter != null)
        {
            currentSegmentHeigth = currentMeshFilter.GetRealHeigth();
        }

        return new Vector3(_buildPoint.position.x, currentSegment.position.y + currentSegmentHeigth / 2 + _blockHeigth / 2, _buildPoint.position.z);
    }
}
