using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<ItemSO> StartItems = new List<ItemSO>();
    public Dictionary<ItemSO, int> InventoryItems = new Dictionary<ItemSO, int>();
    public Action<ItemSO, int> onItemAdded;
    private bool pickUp;
    private ItemSO item_data;
    private GameObject game_obj;

    // Start is called before the first frame update
    void Awake()
    {
        pickUp = false;

        InventoryItems = new Dictionary<ItemSO, int>();
        for (var i = 0; i < StartItems.Count; i++)
        {
            AddItem(StartItems[i]);
        }
    }

    void AddItem(ItemSO item)
    {
        if (InventoryItems.ContainsKey(item))
        {
            // якщо предмет уже Ї в ≥нвентар≥, зб≥льшуЇмо к≥льк≥сть на 1.
            item.Amount++;
        }
        else
        {
            // якщо предмету немаЇ в ≥нвентар≥, додаЇмо його з к≥льк≥стю 1.
            item.Amount = 1;
            InventoryItems[item] = 1;
        }

        onItemAdded?.Invoke(item, InventoryItems[item]);
    }

    private void Update()
    {
        if (pickUp && Input.GetKeyDown(KeyCode.T))
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
