using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IventoryWindow : MonoBehaviour
{
    [SerializeField] Inventory targetInventory;
    [SerializeField] RectTransform itemsPanel;
    List<GameObject> drawnIcons = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        targetInventory.onItemAdded += OnItemAdded;
        Redraw();
    }

    void OnItemAdded(ItemSO obj) => Redraw();
    
    void Redraw()
    {
        ClearDown();
        for(var i = 0; i < targetInventory.InventoryItems.Count; i++)
        {
            var item  = targetInventory.InventoryItems[i];
            var icon = new GameObject("Icon");
            icon.AddComponent<Image>().sprite = item.Sprite;
            icon.transform.SetParent(itemsPanel);
            drawnIcons.Add(icon);
        }
    }

    void ClearDown()
    {
        for(var i = 0; i < drawnIcons.Count; i++)
        {
            Destroy(drawnIcons[i]);
        }
        drawnIcons.Clear();
    }
}
