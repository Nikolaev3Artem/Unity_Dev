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

            // ����������, �� ������ ��� ����� �������� ��� ������
            if (!drawnIcons.ContainsKey(item))
            {
                // �������� ������� ������ ��� ������ ���������
                var icon = new GameObject("Icon");

                // �������� ��������� Image ��� ����������� ����������� ��������
                var imageComponent = icon.AddComponent<Image>();
                imageComponent.sprite = item.Sprite;

                // �������� ��������� ������ ��� ����������� ���������� ���������
                var textAmount = new GameObject("AmountText").AddComponent<Text>();
                textAmount.text = item.Amount.ToString();
                textAmount.color = Color.white;
                textAmount.font = AmountFont;
                textAmount.alignment = TextAnchor.LowerRight;

                // ���������� ��������� ��� ��������
                icon.transform.SetParent(itemsPanel);
                textAmount.transform.SetParent(icon.transform);

                // ���������� ������� � ������� ������ (����� ������������� ��������� � ����������� �� ������ �������)
                textAmount.rectTransform.anchoredPosition = new Vector2(0, 0); // ���������� �������
                textAmount.rectTransform.sizeDelta = new Vector2(40, 40); // ���������� ������

                // �������� ������ � ������� drawnIcons
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
