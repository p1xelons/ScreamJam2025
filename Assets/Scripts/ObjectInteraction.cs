using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ObjectInteraction : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToInventory()
    {
        inventory.Add(this.gameObject);
    }

    
}
