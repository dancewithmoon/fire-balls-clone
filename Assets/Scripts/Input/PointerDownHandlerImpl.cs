using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerDownHandlerImpl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPointerDown;

    public event Action PointerDown;

    private void Update()
    {
        if (isPointerDown == true)
        {
            PointerDown?.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
    }
}
