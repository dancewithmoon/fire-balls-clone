using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerDownHandlerImpl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private IEnumerator invokePointerDown;

    public event Action PointerDown;

    private void Awake()
    {
        invokePointerDown = InvokePointerDown();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(invokePointerDown);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopCoroutine(invokePointerDown);
    }

    private IEnumerator InvokePointerDown()
    {
        while (true)
        {
            PointerDown?.Invoke();
            yield return null;
        }
    }
}
