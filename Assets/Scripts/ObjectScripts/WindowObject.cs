using UnityEngine;

public class WindowObject : MonoBehaviour, IInteractable
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
