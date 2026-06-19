using UnityEngine;

public class StartUIManager : MonoBehaviour
{
    public GameObject characterSelectPanel;

    public void OpenCharacterSelect()
    {
        characterSelectPanel.SetActive(true);
    }
}