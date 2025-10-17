using UnityEngine;

public class CalendarObject : MonoBehaviour, IInteractable
{

    public void OnClickAction()
    {

    }

    void Start()
    {
        InteractablesManager.AddToInteractablesEvent.Invoke(transform);
    }

}
