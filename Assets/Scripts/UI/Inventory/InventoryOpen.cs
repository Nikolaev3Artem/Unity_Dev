using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpen : MonoBehaviour
{
    public GameObject inventoryPanel; // Посилання на панель меню

    private void Start()
    {
        // Приховуємо панель меню при початковому завантаженні гри
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        // Відкриття і закриття меню за допомогою клавіші "Esc"
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        // Перевіряємо, чи меню відображене і змінюємо його стан
        bool isMenuActive = inventoryPanel.activeSelf;
        inventoryPanel.SetActive(!isMenuActive);
    }
}
