using TMPro;
using UnityEngine;

[DefaultExecutionOrder(-1)]
[RequireComponent(typeof(TMP_Text))]
public class TowerHeightView : MonoBehaviour
{
    private TMP_Text _height;

    private void Awake()
    {
        _height = GetComponent<TMP_Text>();
    }

    public void OnHeightUpdated(int height)
    {
        _height.text = height.ToString();
    }
}
