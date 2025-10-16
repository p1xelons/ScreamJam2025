using UnityEngine;

public class TestObject : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {
        Debug.Log("You clicked on the thing");
    }

    void OnEnable()
    {
        InteractablesManager.AddToInteractablesEvent.Invoke(transform);
    }

    void OnDisable()
    {
        InteractablesManager.RemoveFromInteractablesEvent.Invoke(transform);
    }
}
