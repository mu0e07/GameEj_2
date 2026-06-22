using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public void SelectCharacter(int index)
    {
        CharacterSelection.SelectedCharacter = index;

        SceneManager.LoadScene("GameScene");
    }
}