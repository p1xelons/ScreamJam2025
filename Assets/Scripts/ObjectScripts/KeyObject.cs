using UnityEngine;

public class KeyObject : MonoBehaviour, IInteractable
{
    public Dialogue dialogue;
    public InventoryManager inventory;

    public GameObject key;

    public void OnClickAction()
    {
        dialogue.TriggerDialogue();

        inventory.AddItem("Key", new Vector3(-9, 4, 0));

        Destroy(key);

    }

    void Start()
    {
        InteractablesManager.AddToInteractablesEvent.Invoke(transform);
    }

}
