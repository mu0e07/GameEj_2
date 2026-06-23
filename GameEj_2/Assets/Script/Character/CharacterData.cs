using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Game/Character Data")]
public class CharacterData : ScriptableObject
{
    [Header("기본 정보")]
    public string characterName;

    [Header("능력치")]
    public int maxHP;
    public int attack;
    public float moveSpeed;
    public float attackSpeed;
    public float criticalChance;
    public GameObject bulletPrefab;
}