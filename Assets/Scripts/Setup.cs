using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private PointerDownHandlerImpl _input;

    [Header("Models")]
    [SerializeField] private Tank _tank;

    private void OnEnable()
    {
        _input.PointerDown += _tank.TryShoot;
    }

    private void OnDisable()
    {
        _input.PointerDown -= _tank.TryShoot;
    }
}
