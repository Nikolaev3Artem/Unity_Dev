using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    string filePath;
    //public List<GameObject> EnemySaves = new List<GameObject>();
    public List<GameObject> ObjectsSaves = new List<GameObject>();

    private void Start()
    {
        filePath = Application.persistentDataPath + "/save.gamesave";
    }

    //public void SaveGame()
    //{
    //    BinaryFormatter bf = new BinaryFormatter();
    //    FileStream fs = new FileStream(filePath, FileMode.Create);

    //    Save save = new Save();

    //    save.SaveEnemies(EnemySaves);
    //    bf.Serialize(fs, save);
    //    fs.Close();
    //}

    //public void LoadGame()
    //{
    //    if(!File.Exists(filePath))
    //    {
    //        return;
    //    }
    //    BinaryFormatter bf = new BinaryFormatter();
    //    FileStream fs = new FileStream(filePath, FileMode.Open);

    //    Save save = (Save)bf.Deserialize(fs);
    //    fs.Close();

    //    int i = 0;
    //    foreach(var enemy in save.EnemiesData)
    //    {
    //        EnemySaves[i].GetComponent<EnemyMovement>().LoadData(enemy);
    //        i++;
    //    }
    //}
}

//[System.Serializable]
//public class Save
//{
    //[System.Serializable]
    //public struct Vec3
    //{
    //    public float x, y, z;

    //    public Vec3(float x, float y, float z)
    //    {
    //        this.x = x;
    //        this.y = y;
    //        this.z = z;
    //    }
    //}

    //[System.Serializable]
    //public struct ObjectsSaveData
    //{
    //    public Vec3 Position;

    //    public ObjectsSaveData(Vec3 pos)
    //    {
    //        Position = pos;
    //    }

    //    public List<ObjectsSaveData>
    //}


    //[System.Serializable]
    //public struct EnemySaveData
    //{
    //  public Vec3 Position, Direction;

    //    public EnemySaveData(Vec3 pos, Vec3 dir)
    //    {
    //        Position = pos;
    //        Direction = dir;
    //    }
    //}

    //public List<EnemySaveData> EnemiesData = new List<EnemySaveData>();

    //public void SaveEnemies(List<EnemySaveData> enemies)
    //{
    //  foreach(var go in enemies)
    //  {
    //        var em = go.GetComponent<EnemyMovement>();

    //        Vec3 pos = new Vec3(go.transform.position.x, go.transform.position.y, go.transform.position.z);
    //        Vec3 dir = new Vec3(go.DirectionVec.x, go.DirectionVec.y, go.DirectionVec.z);
    //        EnemiesData.Add(new EnemySaveData(pos,dir));
    //  }
    //}
// }