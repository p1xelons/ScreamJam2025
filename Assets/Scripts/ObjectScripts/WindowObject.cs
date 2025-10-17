using UnityEngine;

public class WindowObject : MonoBehaviour, IInteractable
{
    public Dialogue dialogue;
    public InventoryManager inventoryManager;
    public Inventory inventory;
    public StartGame gameOver;

    public void OnClickAction()
    {
        if (inventory != null)
        {
            foreach (InventoryItem i in inventory.items)
            {
                if (i.itemName == "Key")
                {
                    gameOver.GameOver();
                }
            }
        }

        dialogue.TriggerDialogue();
    }

    void Start()
    {
        inventory = inventoryManager.inventory;

        InteractablesManager.AddToInteractablesEvent.Invoke(transform);
    }

}
