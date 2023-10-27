using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager control;
    string filePath;
    //public List<GameObject> EnemySaves = new List<GameObject>();
    public List<GameObject> ObjectsSaves = new List<GameObject>();

    public void Awake()
    {
        filePath = Application.persistentDataPath + "/GameSave.data";
        LoadGame();
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        Save save = new Save();

        save.SaveObjects(ObjectsSaves);
        bf.Serialize(fs, save);
        fs.Close();
    }

    public void LoadGame()
    {
        if (!File.Exists(filePath))
        {
            Debug.Log("Game Saving not found!");
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);

        Save save = (Save)bf.Deserialize(fs);
        fs.Close();
        int i = 0;
        foreach (var item in save.ObjectsData)
        {
            ObjectsSaves[i].GetComponent<SOHolder>().LoadData(item);
            i++;
        }
    }
}

[System.Serializable]
public class Save
{
    [System.Serializable]
    public struct Vec3
    {
        public float x, y, z;

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    [System.Serializable]
    public struct ObjectsSaveData
    {
        public Vec3 Position;
        public bool Exists;

        public ObjectsSaveData(Vec3 pos, bool exists)
        {
            Position = pos;
            Exists = exists;
        }

    }

    public List<ObjectsSaveData> ObjectsData = new List<ObjectsSaveData>();

    public void SaveObjects(List<GameObject> Objects)
    {
        foreach (var go in Objects)
        {
            if (go != null)
            {
                Vec3 pos = new Vec3(go.transform.position.x, go.transform.position.y, go.transform.position.z);
                ObjectsData.Add(new ObjectsSaveData(pos, true));
            }
            else
            {
                Vec3 pos = new Vec3(0,0,0);
                ObjectsData.Add(new ObjectsSaveData(pos,false));
            }
        }
    }

}
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
//    foreach (var go in enemies)
//    {
//        var em = go.GetComponent<EnemyMovement>();

//        Vec3 pos = new Vec3(go.transform.position.x, go.transform.position.y, go.transform.position.z);
//        Vec3 dir = new Vec3(go.DirectionVec.x, go.DirectionVec.y, go.DirectionVec.z);
//        EnemiesData.Add(new EnemySaveData(pos, dir));
//    }
//}
// }