using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOHolder : MonoBehaviour
{
    public ItemSO itemData;
    private bool pickUp;

    private void Start()
    {
        pickUp = false;

    }
    private void Update()
    {
        if (pickUp && Input.GetKeyDown(KeyCode.T))
        {
            PickUp();
        }
    }
    private void OnTriggerEnter2D(Collider2D collectable)
    {
        if (collectable.gameObject.CompareTag("Player"))
        {
            pickUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collectable)
    {
        if (collectable.gameObject.CompareTag("Player"))
        {
            pickUp = false;
        }
    }

    void PickUp()
    {
        Destroy(gameObject);
    }
}
