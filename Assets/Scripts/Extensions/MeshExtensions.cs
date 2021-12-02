using UnityEngine;

public static class MeshExtensions
{
    public static float GetRealHeight(this MeshFilter obj)
    {
        return obj.transform.localScale.y * obj.sharedMesh.bounds.size.y;
    }
}

