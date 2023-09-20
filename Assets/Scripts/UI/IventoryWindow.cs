using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IventoryWindow : MonoBehaviour
{
    [SerializeField] Inventory targetInventory;
    [SerializeField] RectTransform itemsPanel;
    Dictionary<ItemSO, GameObject> drawnIcons = new Dictionary<ItemSO, GameObject>();
    public Font AmountFont;

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
                // Создайте игровой объект для ячейки инвентаря
                var icon = new GameObject("Icon");

                // Добавьте компонент Image для отображения изображения предмета
                var imageComponent = icon.AddComponent<Image>();
                imageComponent.sprite = item.Sprite;

                // Создайте текстовый объект для отображения количества предметов
                var textAmount = new GameObject("AmountText").AddComponent<Text>();
                textAmount.text = item.Amount.ToString();
                textAmount.color = Color.white;
                textAmount.font = AmountFont;
                textAmount.alignment = TextAnchor.LowerRight;

                // Установите родителей для объектов
                icon.transform.SetParent(itemsPanel);
                textAmount.transform.SetParent(icon.transform);

                // Установите позиции и размеры текста (может потребоваться доработка в зависимости от вашего дизайна)
                textAmount.rectTransform.anchoredPosition = new Vector2(0, 0); // Установите позицию
                textAmount.rectTransform.sizeDelta = new Vector2(40, 40); // Установите размер

                // Добавьте объект в словарь drawnIcons
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
