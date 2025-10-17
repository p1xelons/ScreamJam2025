using UnityEngine;

public class GroceryListObject : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {

    }

    void Start()
    {
        InteractablesManager.AddToInteractablesEvent.Invoke(transform);
    }
}
