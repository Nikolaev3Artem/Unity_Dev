using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel; // Посилання на панель меню

    private void Start()
    {
        // Приховуємо панель меню при початковому завантаженні гри
        menuPanel.SetActive(false);
    }

    private void Update()
    {
        // Відкриття і закриття меню за допомогою клавіші "Esc"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        // Перевіряємо, чи меню відображене і змінюємо його стан
        bool isMenuActive = menuPanel.activeSelf;
        menuPanel.SetActive(!isMenuActive);

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
