using UnityEngine;

public class VentObject : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {

    }

    void Start()
    {
        InteractablesManager.AddToInteractablesEvent.Invoke(transform);
    }
}
