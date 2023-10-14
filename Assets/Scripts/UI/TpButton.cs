using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TpButton : MonoBehaviour
{
    public Button Button; // Посилання на кнопку, яку будемо використовувати для зміни сцени
    public int wait; // Час затримки перед зміною сцени
    public string IsLand; // Назва сцени, на яку потрібно перейти
    public TextMeshProUGUI countdownText; // Поле для відображення зворотнього відліку за допомогою TMP

    private void Start()
    {
        // Додаємо обробник події для кнопки, який викликає метод LoadScene при кліку
        Button.onClick.AddListener(() => LoadScene(IsLand));
    }

    // Корутина для здійснення зворотнього відліку та зміни сцени
    private IEnumerator MyCoroutine(string sceneName)
    {
        Debug.Log("Початок корутини");

        float timeLeft = wait; // Час, який залишився

        while (timeLeft > 0)
        {
            countdownText.text = "Залишилося: " + timeLeft.ToString("0");
            yield return new WaitForSeconds(1f); // Очікування 1 секунди
            timeLeft -= 1f;
        }

        countdownText.text = ""; // Забрати відображення після закінчення затримки

        SceneManager.LoadScene(sceneName); // Змінюємо сцену
        Time.timeScale = 1f; // Відновлюємо час до звичайного значення
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(MyCoroutine(sceneName)); // Запускаємо корутину для зміни сцени з зворотнім відліком
    }
}
