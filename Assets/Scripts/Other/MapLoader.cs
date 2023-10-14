using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLoader : MonoBehaviour
{
    public static string Pastlocation; // Змінна для зберігання назви поточної сцени

    private void OnRectTransformDimensionsChange()
    {
        // Цей метод не має жодної функціональності, тому його можна видалити
    }

    void Update()
    {
        // Перевіряємо, чи натиснута клавіша "M"
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Запам'ятовуємо назву поточної сцени
            Pastlocation = SceneManager.GetActiveScene().name;

            // Завантажуємо сцену "Map"
            LoadScene("Map");
        }
    }

    public void LoadScene(string sceneName)
    {
        // Завантажуємо вказану сцену і відновлюємо час гри
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}
