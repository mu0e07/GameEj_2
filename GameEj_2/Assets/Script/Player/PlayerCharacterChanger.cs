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
    public CharacterData[] characterDatas;

    void Awake()
    {
        PlayerController player = GetComponent<PlayerController>();
        PlayerStats stats = GetComponent<PlayerStats>();

        // 선택한 캐릭터의 스프라이트 가져오기
        CharacterSprites data = characters[CharacterSelection.SelectedCharacter];

        // 선택한 캐릭터의 능력치 가져오기
        CharacterData statData = characterDatas[CharacterSelection.SelectedCharacter];

        // 능력치 적용
        stats.maxHP = statData.maxHP;
        stats.currentHP = statData.maxHP;
        stats.attack = statData.attack;
        stats.moveSpeed = statData.moveSpeed;
        stats.attackSpeed = statData.attackSpeed;
        stats.criticalChance = statData.criticalChance;

        // 스프라이트 적용
        player.SetCharacterSprites(
            data.up,
            data.down,
            data.left,
            data.right
        );
    }
}