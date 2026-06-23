using UnityEngine;

[CreateAssetMenu(fileName = "LevelData",
menuName = "Game/Level Data")]
public class LevelData : ScriptableObject
{
    public MonsterData[] monsters;

    public float spawnInterval = 1f;

    public float levelTime = 60f;
}
