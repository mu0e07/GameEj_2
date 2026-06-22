using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Game/Monster Data")]
public class MonsterData : ScriptableObject
{
    [Header("기본 정보")]
    public string monsterName;

    public Sprite sprite;

    [Header("능력치")]
    public int maxHP;

    public int attack;

    public float moveSpeed;

    public int exp;

    public int score;
}
