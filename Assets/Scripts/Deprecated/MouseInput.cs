using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MouseInput : MonoBehaviour
{

    public Vector2 WorldPos { get; private set; }
    public event Action Clicked;

    private void OnLook(InputValue value)
    {
        WorldPos = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }

    private void OnAction(InputValue _)
    {
        Clicked?.Invoke();
    }
}
