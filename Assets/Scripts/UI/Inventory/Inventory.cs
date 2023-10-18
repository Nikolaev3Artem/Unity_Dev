using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject Player;
    public List<ItemSO> InventoryItems = new List<ItemSO>();
    public event EventHandler OnItemListChanged;
    private bool pickUp;
    private ItemSO item_data;
    private GameObject game_obj;
    public int inventoryMaxSize = 20;
    private Rigidbody2D player_rb;
    private GameObject XPBar;
    private int player_exp;

    // �������� ��� �� ��� ������� �� ���
    void Awake()
    {
        player_rb = Player.GetComponent<Rigidbody2D>();
        pickUp = false;
        InventoryItems = new List<ItemSO>();
        XPBar = Player.GetComponent<PlayerData>().XPBar;
        player_exp = Player.GetComponent<PlayerData>().exp;

    }

    // ������� ��������� �������� � ��������
    void AddItem(ItemSO item)
    {

        if (item.Stackable)
        {
            bool ItemAlreadyInInventory = false;
            // ����������� �� ��������� � ��������
            foreach (ItemSO InvItem in InventoryItems)
            {
                // ���������� �� ������� ���������� � ��������
                // ���� ������� ����������, ���������� � ���� �� ����, ������������ ���������(����)
                if (InvItem.Name == item.Name)
                {
                    player_rb.drag += item.Weight;
                    InvItem.Amount += item.Amount;
                    ItemAlreadyInInventory = true;
                }
            }
            // ���� �������� ���� � �������� ���������� � ���� ����� �������
            if (!ItemAlreadyInInventory)
            {
                player_rb.drag += item.Weight;
                InventoryItems.Add(item);
                item.Amount = 1;
                XPBar.GetComponent<XPBar>().SetXPBarValue(item.collectableExp);
            }

        }
        else
        {
            player_rb.drag += item.Weight;
            InventoryItems.Add(item);
            item.Amount = 1;
            XPBar.GetComponent<XPBar>().SetXPBarValue(item.collectableExp);
        }
        // ��������� ����� ��� ������������ UI ���������
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<ItemSO> GetItemList()
    {
        return InventoryItems;
    }

    private void Update()
    {
        // ������� �� ������� ��������, �� ��������� ������, pickUp �������� �� ����� ������� �� ��������
        // ����� ���������� �� � ���� � ��������, ��������� ������� ������� �������� � ����������� ������� �������
        if (pickUp && Input.GetKeyDown(KeyCode.E) && InventoryItems.Count < inventoryMaxSize)
        {
            PickUp(game_obj);
            AddItem(item_data);
        }
    }

    // ���� ������� �������� � ���糺� �������� � ����� Collectable
    private void OnTriggerEnter2D(Collider2D collectable)
    {
        if (collectable.gameObject.CompareTag("Collectable"))
        {
            pickUp = true;
            // �������� ��'���
            game_obj = collectable.gameObject;
            // �������� ���� �� ��'����
            item_data = collectable.gameObject.GetComponent<SOHolder>().ItemData;
        }
    }

    // ������� ���� �������� �� �������� � ��'�����
    private void OnTriggerExit2D(Collider2D collectable)
    {
        if (collectable.gameObject.CompareTag("Collectable"))
        {
            pickUp = false;
        }
    }

    // ������� ��� �������� ��'���� ���� �������
    void PickUp(GameObject obj)
    {
        Destroy(obj);
    }
}
