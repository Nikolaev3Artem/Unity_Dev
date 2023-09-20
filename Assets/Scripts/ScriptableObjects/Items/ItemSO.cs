using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectable", menuName = "Items/Collectable")]
public class ItemSO : ScriptableObject
{
    public Sprite Sprite;
    public string Name;
    public string Description;
    public int Weight;
    public int Amount;

}
