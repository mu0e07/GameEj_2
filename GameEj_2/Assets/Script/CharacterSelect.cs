using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public void SelectCharacter(int index)
    {
        CharacterData.SelectedCharacter = index;

        SceneManager.LoadScene("GameScene");
    }
}