using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Game/Monster Data")]
public class MonsterData : ScriptableObject
{
    public string monsterName;

    public Sprite sprite;

    public int maxHP;

    public int attack;

    public float moveSpeed;

    public int exp;

    public int score;
}
