using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOHolder : MonoBehaviour
{
    [SerializeField] private ItemSO itemData;

    public ItemSO ItemData { get => itemData; }

    // Функція для знищення об'єкту після підняття
    public void PickUp(GameObject obj)
    {
        Destroy(obj);
    }
    public void LoadData(Save.ObjectsSaveData save)
    {
        if (save.Exists)
        {
            transform.position = new Vector3(save.Position.x, save.Position.y, save.Position.z);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
