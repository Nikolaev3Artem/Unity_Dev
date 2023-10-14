using UnityEngine;
using UnityEngine.SceneManagement;

public class MapReturner : MonoBehaviour
{
    // Цей метод не має жодної функціональності, тому його можна видалити
    private void OnRectTransformDimensionsChange()
    {
        // Видаліть цей метод, якщо він не потрібний
    }

    void Update()
    {
        // Перевіряємо, чи натиснута клавіша "M"
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Викликаємо метод LoadScene і передаємо йому невірний аргумент MapLoader.Pastlocation
            // Вам потрібно виправити цю проблему або визначити MapLoader.Pastlocation
            // Якщо MapLoader.Pastlocation - це ім'я сцени, то використовуйте це ім'я.
            LoadScene(MapLoader.Pastlocation);
        }
    }

    public void LoadScene(string sceneName)
    {
        // Завантажуємо вказану сцену і відновлюємо час гри
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}
