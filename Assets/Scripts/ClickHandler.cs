using UnityEngine;
using UnityEngine.Events;

public class ClickHandler : MonoBehaviour
{

    [SerializeField]
    private UnityEvent clicked;

    private MouseInput mouse;

    private BoxCollider2D collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        mouse = GetComponent<MouseInput>();
        mouse.Clicked += MouseOnClicked;
    }

    private void MouseOnClicked()
    {
        if (collider.bounds.Contains(mouse.WorldPos))
        {
            clicked?.Invoke();
        }
    }

}
