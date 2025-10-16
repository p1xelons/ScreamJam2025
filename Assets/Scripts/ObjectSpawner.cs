using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnItems()
    {
        foreach (var item in InventoryManager.Instance.inventory.items)
        {
            // get positon
            Vector3 spawnPos = item.DeserializePosition();
            // initiate object
            GameObject spawnedItem = Instantiate(itemPrefab, spawnPos, Quaternion.identity);
            // set the name
            spawnedItem.name = item.itemName;
        }
    }
}
