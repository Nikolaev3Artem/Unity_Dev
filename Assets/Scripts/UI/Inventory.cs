using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<ItemSO> StartItems = new List<ItemSO>();
    public List<ItemSO> InventoryItems = new List<ItemSO>();
    public Action<ItemSO> onItemAdded;
    private bool pickUp;
    private ItemSO item_data;
    private GameObject game_obj;

    // Start is called before the first frame update
    void Awake()
    {
        pickUp = false;

        InventoryItems = new List<ItemSO>();
        for (var i = 0; i < StartItems.Count; i++)
        {
            AddItem(StartItems[i]);
        }
    }

    void AddItem(ItemSO item)
    {
        InventoryItems.Add(item);
        onItemAdded?.Invoke(item);
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
