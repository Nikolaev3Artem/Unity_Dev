using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel; // Посилання на панель меню

    private void Start()
    {
        // При початковому завантаженні гри приховуємо панель меню
        menuPanel.SetActive(false);
    }

    private void Update()
    {
        // Відкриваємо та закриваємо меню за допомогою клавіші "Esc"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu(); // Викликаємо функцію для перемикання відображення меню
        }
    }

    private void ToggleMenu()
    {
        // Перевіряємо, чи меню відображене, і змінюємо його стан
        bool isMenuActive = menuPanel.activeSelf;
        menuPanel.SetActive(!isMenuActive);

        // Якщо меню відкрите, зупиняємо час гри (змінюємо часовий масштаб на 0), інакше відновлюємо час гри (часовий масштаб 1)
        if (!isMenuActive)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
