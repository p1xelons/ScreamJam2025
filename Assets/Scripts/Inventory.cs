using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<string> items;  // List of item names or IDs

    public Inventory()
    {
        items = new List<string>();
    }
}
public class InventoryManager : MonoBehaviour
{
    public List<string> items;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
