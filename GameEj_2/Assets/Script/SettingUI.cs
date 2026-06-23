using UnityEngine;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;

    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isOpen = !isOpen;

            settingPanel.SetActive(isOpen);

            Time.timeScale = isOpen ? 0f : 1f;
        }
    }

    public void ContinueGame()
    {
        isOpen = false;

        settingPanel.SetActive(false);

        Time.timeScale = 1f;
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