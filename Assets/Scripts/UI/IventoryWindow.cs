using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IventoryWindow : MonoBehaviour
{
    [SerializeField] Inventory targetInventory;
    [SerializeField] RectTransform itemsPanel;
    // Start is called before the first frame update
    void Start()
    {
        Redraw();
    }
    
    void Redraw()
    {
        for(var i = 0; i < targetInventory.InventoryItems.Count; i++)
        {
            var item  = targetInventory.InventoryItems[i];
            var icon = new GameObject("Icon");
            icon.AddComponent<Image>().sprite = item.Sprite;
            icon.transform.SetParent(itemsPanel);
        }
    }
}
