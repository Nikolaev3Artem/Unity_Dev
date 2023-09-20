using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IventoryWindow : MonoBehaviour
{
    [SerializeField] Inventory targetInventory;
    [SerializeField] RectTransform itemsPanel;
    Dictionary<ItemSO, GameObject> drawnIcons = new Dictionary<ItemSO, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        targetInventory.onItemAdded += OnItemAdded;
        Redraw();
    }

    void OnItemAdded(ItemSO item, int itemCount)
    {
        Redraw();
    }

    void Redraw()
    {
        ClearDown();
        foreach (var itemEntry in targetInventory.InventoryItems)
        {
            var item = itemEntry.Key;
            var itemCount = itemEntry.Value;

            // Перевіряємо, чи іконка для цього предмета вже додана
            if (!drawnIcons.ContainsKey(item))
            {
                var icon = new GameObject("Icon");
                icon.AddComponent<Image>().sprite = item.Sprite;
                icon.transform.SetParent(itemsPanel);
                drawnIcons[item] = icon;
            }
            Debug.Log(item.name + " " + item.Amount);
        }
    }

    void ClearDown()
    {
        foreach (var iconEntry in drawnIcons)
        {
            Destroy(iconEntry.Value);
        }
        drawnIcons.Clear();
    }
}
