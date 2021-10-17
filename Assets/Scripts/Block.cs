using DG.Tweening;
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
    
    public void MoveDown(float distance, float movingSpeed)
    {
        transform.DOMoveY(transform.position.y - distance, movingSpeed);
    }

    public float GetRealHeigth()
    {
        if(TryGetComponent(out MeshFilter meshFilter))
        {
            return meshFilter.GetRealHeigth();  
        }

        Debug.LogError($"Could not found {nameof(MeshFilter)} component!");
        return 0;
    }
}
