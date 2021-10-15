using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    public event Action<Block> Broken;

    public void Break()
    {
        Broken?.Invoke(this);
        Destroy(gameObject);
    }

    public float GetRealHeigth()
    {
        var meshFilter = GetComponentInChildren<MeshFilter>();
        if(meshFilter == null)
        {
            Debug.LogError($"Could not found {nameof(MeshFilter)} component!");
            return 0;
        }
        return meshFilter.GetRealHeigth();
    }
}
