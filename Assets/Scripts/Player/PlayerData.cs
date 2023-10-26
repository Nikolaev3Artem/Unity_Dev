using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int exp;
    public int expForLvl;
    public int level;
    public int armor;
    public GameObject XPBar;

    //public void LoadData(Save.ObjectsSaveData save)
    //{
    //    transform.position = new Vector3(save.Position.x, save.Position.y, save.Position.z);
    //}
}
