using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public string positionSerialized;

    public InventoryItem(string name, Vector3 pos)
    {
        itemName = name;
        positionSerialized = SerializeVector3(pos);
    }

    // format: "x,y,z"
    private string SerializeVector3(Vector3 position)
    {
        return position.x + "," + position.y + "," + position.z;
    }

    // turn back to vector3
    public Vector3 DeserializePosition()
    {
        string[] parts = positionSerialized.Split(',');
        float x = float.Parse(parts[0]);
        float y = float.Parse(parts[1]);
        float z = float.Parse(parts[2]);
        return new Vector3(x, y, z);
    }
}
public class Inventory
{
    public List<InventoryItem> items;

    public Inventory()
    {
        items = new List<InventoryItem>();
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
    public void AddItem(string itemName, Vector3 position)
    {
        InventoryItem itemToAdd = new InventoryItem(itemName, position);
        if (!inventory.items.Contains(itemToAdd))
        {
            inventory.items.Add(itemToAdd);
            SaveInventory();
        }
    }

    /// <summary>
    /// removes item from inventroy
    /// </summary>
    /// <param name="itemName">name of item to add</param>
    public void RemoveItem(string itemName, Vector3 position)
    {
        InventoryItem itemToAdd = new InventoryItem(itemName, position);
        if (inventory.items.Contains(itemToAdd))
        {
            inventory.items.Remove(itemToAdd);
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
