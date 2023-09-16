using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> StartItems = new List<Item>();
    public List<Item> InventoryItems = new List<Item>();

    // Start is called before the first frame update
    void Awake()
    {
        InventoryItems = new List<Item>();
        for (var i = 0; i < StartItems.Count; i++)
        {
            AddItem(StartItems[i]);
        }
    }

    void AddItem(Item item)
    {
        InventoryItems.Add(item);
    }
}
