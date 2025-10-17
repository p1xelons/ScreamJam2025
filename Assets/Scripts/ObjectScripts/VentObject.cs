using UnityEngine;

public class VentObject : MonoBehaviour, IInteractable
{
    public Dialogue dialogue;
    public void OnClickAction()
    {
        dialogue.TriggerDialogue();
    }

    void Start()
    {
        InteractablesManager.AddToInteractablesEvent.Invoke(transform);
    }

}
