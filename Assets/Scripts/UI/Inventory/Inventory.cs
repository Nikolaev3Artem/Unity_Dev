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

    // Получаємо все що нам потрібно від гри
    void Awake()
    {
        player_rb = Player.GetComponent<Rigidbody2D>();
        pickUp = false;
        InventoryItems = new List<ItemSO>();
        XPBar = Player.GetComponent<PlayerData>().XPBar;
        player_exp = Player.GetComponent<PlayerData>().exp;

    }

    // Функція додавання предмету в інвентар
    void AddItem(ItemSO item)
    {

        if (item.Stackable)
        {
            bool ItemAlreadyInInventory = false;
            // Проходимось по предметам в інвентарі
            foreach (ItemSO InvItem in InventoryItems)
            {
                // Перевіряємо чи предмет находиться в інвентарі
                // Якщо предмет находиться, добавляємо в слот ще один, заповільнюємо персонажа(вага)
                if (InvItem.Name == item.Name)
                {
                    player_rb.drag += item.Weight;
                    InvItem.Amount += item.Amount;
                    ItemAlreadyInInventory = true;
                }
            }
            // Якщо предмету немає в інвентарі добавляємо в слот новий предмет
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
        // Викликаємо івент для перемальовки UI інвентару
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<ItemSO> GetItemList()
    {
        return InventoryItems;
    }

    private void Update()
    {
        // Слідкуємо за підбором предмету, за допомогою клавіші, pickUp перевірка чи ігрок близько до предмету
        // Також перевіряємо чи є місце в інвентарі, порівнюючи кількість наявних предметів і максимально можливу кількість
        if (pickUp && Input.GetKeyDown(KeyCode.E) && InventoryItems.Count < inventoryMaxSize)
        {
            PickUp(game_obj);
            AddItem(item_data);
        }
    }

    // Якщо гравець зіткнувся з колізією предмету з тегом Collectable
    private void OnTriggerEnter2D(Collider2D collectable)
    {
        if (collectable.gameObject.CompareTag("Collectable"))
        {
            pickUp = true;
            // Получаємо об'єкт
            game_obj = collectable.gameObject;
            // Получаємо данні від об'єкту
            item_data = collectable.gameObject.GetComponent<SOHolder>().ItemData;
        }
    }

    // Слідкуємо якщо персонаж не контактує з об'єктом
    private void OnTriggerExit2D(Collider2D collectable)
    {
        if (collectable.gameObject.CompareTag("Collectable"))
        {
            pickUp = false;
        }
    }

    // Функція для знищення об'єкту після підняття
    void PickUp(GameObject obj)
    {
        Destroy(obj);
    }
}
