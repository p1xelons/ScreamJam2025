using UnityEngine;

public class DeskObject : MonoBehaviour, IInteractable
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
