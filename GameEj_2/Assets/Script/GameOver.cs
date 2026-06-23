using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI scoreText;

    public void ShowGameOver(int finalScore)
    {
        panel.SetActive(true);

        scoreText.text = "최종 점수 : " + finalScore;

        Time.timeScale = 0f;
    }

    public void GoToTitle()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("UI");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
