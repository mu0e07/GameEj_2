using UnityEngine;

public class PlayerCharacterChanger : MonoBehaviour
{
    [System.Serializable]
    public class CharacterSprites
    {
        public Sprite[] up;
        public Sprite[] down;
        public Sprite[] left;
        public Sprite[] right;
    }

    public CharacterSprites[] characters;

    void Start()
    {
        PlayerController player = GetComponent<PlayerController>();

        CharacterSprites data = characters[CharacterData.SelectedCharacter];

        player.SetCharacterSprites(
            data.up,
            data.down,
            data.left,
            data.right
        );
    }
}