using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class Inventory
{
    public List<string> items;

    public Inventory()
    {
        items = new List<string>();
    }
}
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Inventory inventory;
    private string filePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        filePath = Path.Combine(Application.persistentDataPath, "inventory.json");

        // load inventory
        LoadInventory();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// adds item to inventory
    /// </summary>
    /// <param name="itemName">name of item to add</param>
    public void AddItem(string itemName)
    {
        if (!inventory.items.Contains(itemName))
        {
            inventory.items.Add(itemName);
            SaveInventory();
        }
    }

    /// <summary>
    /// removes item from inventroy
    /// </summary>
    /// <param name="itemName">name of item to add</param>
    public void RemoveItem(string itemName)
    {
        if (inventory.items.Contains(itemName))
        {
            inventory.items.Remove(itemName);
            SaveInventory();
        }
    }

    /// <summary>
    /// save to the file
    /// </summary>
    private void SaveInventory()
    {
        string json = JsonUtility.ToJson(inventory);
        File.WriteAllText(filePath, json);
    }

    /// <summary>
    /// load from the file
    /// </summary>
    private void LoadInventory()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            inventory = JsonUtility.FromJson<Inventory>(json);
        }
        else
        {
            inventory = new Inventory();
        }
    }
}
