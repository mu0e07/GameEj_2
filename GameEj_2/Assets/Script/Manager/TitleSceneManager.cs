using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameInput;

    public void StartGame()
    {
        string nickname = nicknameInput.text;

        if (string.IsNullOrEmpty(nickname))
            nickname = "Player";

        PlayerPrefs.SetString("Nickname", nickname);

        SceneManager.LoadScene("GameScene");
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