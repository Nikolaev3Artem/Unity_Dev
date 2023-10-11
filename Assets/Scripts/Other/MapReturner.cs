using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.FilePathAttribute;
using static UnityEditor.ShaderData;

public class MapReturner : MonoBehaviour


{

    
    private void OnRectTransformDimensionsChange()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            LoadScene(MapLoader.Pastlocation);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}