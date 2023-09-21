using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemSO> InventoryItems = new List<ItemSO>();
    public event EventHandler OnItemListChanged;
    private bool pickUp;
    private ItemSO item_data;
    private GameObject game_obj;
    public int inventoryMaxSize = 20;

    // Start is called before the first frame update
    void Awake()
    {
        pickUp = false;
        InventoryItems = new List<ItemSO>();
    }

    void AddItem(ItemSO item)
    {
        if (item.Stackable)
        {
            bool ItemAlreadyInInventory = false;
            foreach (ItemSO InvItem in InventoryItems)
            {
                if (InvItem.Name == item.Name)
                {
                    InvItem.Amount++;
                    ItemAlreadyInInventory = true;
                }
            }
            if(!ItemAlreadyInInventory)
            {
                InventoryItems.Add(item);
            }
        }
        else
        {
            InventoryItems.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<ItemSO> GetItemList()
    {
        return InventoryItems;
    }

    private void Update()
    {
        if (pickUp && Input.GetKeyDown(KeyCode.E) && InventoryItems.Count < inventoryMaxSize)
        {
            PickUp(game_obj);
            AddItem(item_data);
        }
    }

    private void OnTriggerEnter2D(Collider2D collectable)
    {
        if (collectable.gameObject.CompareTag("Collectable"))
        {
            pickUp = true;
            game_obj = collectable.gameObject;
            item_data = collectable.gameObject.GetComponent<SOHolder>().ItemData;
        }
    }

    private void OnTriggerExit2D(Collider2D collectable)
    {
        if (collectable.gameObject.CompareTag("Collectable"))
        {
            pickUp = false;
        }
    }

    void PickUp(GameObject obj)
    {
        Destroy(obj);
    }
}
