using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<ItemSO> StartItems = new List<ItemSO>();
    public List<ItemSO> InventoryItems = new List<ItemSO>();

    // Start is called before the first frame update
    void Awake()
    {
        InventoryItems = new List<ItemSO>();
        for (var i = 0; i < StartItems.Count; i++)
        {
            AddItem(StartItems[i]);
        }
    }

    void AddItem(ItemSO item)
    {
        InventoryItems.Add(item);
    }


}
