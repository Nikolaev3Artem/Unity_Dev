using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TpButton : MonoBehaviour
{
    public Button Button;
    public int wait;
    public string IsLand;

    void Start()
    {
        Button.onClick.AddListener(() => LoadScene(IsLand));
    }

    private IEnumerator MyCoroutine(string sceneName)
    {
        yield return new WaitForSeconds(wait);

        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(MyCoroutine(sceneName));
    }
}