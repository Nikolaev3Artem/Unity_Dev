using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLoader : MonoBehaviour


{

    public static string Pastlocation;

    private void OnRectTransformDimensionsChange()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Pastlocation = SceneManager.GetActiveScene().name;

            LoadScene("Map");

        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}