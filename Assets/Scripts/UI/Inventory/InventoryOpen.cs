using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpen : MonoBehaviour
{
    public GameObject inventoryPanel; // ��������� �� ������ ����

    private void Start()
    {
        // ��������� ������ ���� ��� ����������� ����������� ���
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        // ³������� � �������� ���� �� ��������� ������ "Esc"
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        // ����������, �� ���� ���������� � ������� ���� ����
        bool isMenuActive = inventoryPanel.activeSelf;
        inventoryPanel.SetActive(!isMenuActive);
    }
}
