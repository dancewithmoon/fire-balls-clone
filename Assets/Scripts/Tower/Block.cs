using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyEffect;
    private MeshRenderer _meshRenderer;

    public float RealHeight => GetComponent<MeshFilter>().GetRealHeight();

    public event Action<Block> Broken;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Break()
    {
        Broken?.Invoke(this);
        ParticleSystemRenderer renderer = Instantiate(_destroyEffect, transform.position, _destroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
        renderer.material.color = _meshRenderer.material.color;
        Destroy(gameObject);
    }

    public void SetColor(Color color)
    {
        _meshRenderer.material.SetColor("_Color", color);
        Color.RGBToHSV(color, out float H, out float S, out float V);
        V = Mathf.Clamp(V - 0.2f, 0, 1);
        Color shadeColor = Color.HSVToRGB(H, S, V);
        _meshRenderer.material.SetColor("_ColorDim", shadeColor);
    }
    
    public void MoveDown(float distance, float movingSpeed)
    {
        transform.DOMoveY(transform.position.y - distance, movingSpeed);
    }
}
