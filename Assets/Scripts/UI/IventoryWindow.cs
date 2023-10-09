using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using static UnityEditor.Progress;

public class IventoryWindow : MonoBehaviour
{
    [SerializeField] Inventory targetInventory;
    [SerializeField] RectTransform itemsPanel;
    List<GameObject> drawnIcons = new List<GameObject>();
    public Font AmountFont;

    private void Awake()
    {
        targetInventory.OnItemListChanged += Inventory_OnItemListChanged;
        Redraw();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        Redraw();
    }

    void Redraw()
    {
        ClearDown();
        foreach (var item in targetInventory.GetItemList())
        {
            AddIcon(item);
        }
        
    }

    void AddIcon(ItemSO item)
    {
        // �������� ������� ������ ��� ������ ���������
        var icon = new GameObject("Icon");

        // �������� ��������� Image ��� ����������� ����������� ��������
        var imageComponent = icon.AddComponent<Image>();
        imageComponent.sprite = item.Sprite;
        icon.transform.SetParent(itemsPanel);

        if (item.Stackable)
        {

            // �������� ��������� ������ ��� ����������� ���������� ���������
            var textAmount = new GameObject("AmountText").AddComponent<Text>();
            textAmount.text = item.Amount.ToString();
            textAmount.color = Color.white;
            textAmount.font = AmountFont;
            textAmount.alignment = TextAnchor.LowerRight;

            // ���������� ��������� ��� ��������
            textAmount.transform.SetParent(icon.transform);

            // ���������� ������� � ������� ������ (����� ������������� ��������� � ����������� �� ������ �������)
            textAmount.rectTransform.anchoredPosition = new Vector2(0, 0); // ���������� �������
            textAmount.rectTransform.sizeDelta = new Vector2(40, 40); // ���������� ������
        }

        // �������� ������ � ������� drawnIcons
        drawnIcons.Add(icon);
    }

    void ClearDown()
    {
        foreach (var icon in drawnIcons)
        {
            Destroy(icon);
        }
        drawnIcons.Clear();
    }
}
