using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "Collectable", menuName = "Items/Collectable")]
public class ItemSO : ScriptableObject
{
    public Sprite Sprite;
    public string Name;
    public string Description;
    public int Weight;
    public int Amount;
    public bool Stackable;
    public int MaxStack;
    public int id;
}