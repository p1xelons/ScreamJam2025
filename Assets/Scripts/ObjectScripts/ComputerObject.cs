using UnityEngine;

public class ComputerObject : MonoBehaviour, IInteractable
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
