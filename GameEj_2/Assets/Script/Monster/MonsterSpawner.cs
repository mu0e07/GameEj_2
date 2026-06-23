using UnityEngine;
using TMPro;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    
    [Header("소환 거리 설정")]
    [SerializeField] private float minSpawnDistance = 5f;
    [SerializeField] private float maxSpawnDistance = 10f;

    [Header("맵 크기")]
    [SerializeField] private float minX = -15f;
    [SerializeField] private float maxX = 15f;
    [SerializeField] private float minY = -15f;
    [SerializeField] private float maxY = 15f;

    private Transform playerTransform;
    private float nextSpawnTime;
    [SerializeField]
    private LevelData currentLevel;

    [SerializeField] private LevelData level1;
    [SerializeField] private LevelData level2;
    [SerializeField] private LevelData level3;

    [SerializeField]
    private TextMeshProUGUI levelText;

    private int currentLevelIndex = 1;

    private float gameTime;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
            playerTransform = player.transform;

        currentLevel = level1;

        levelText.text = "Level 1";
    }

    void Update()
    {
        if (playerTransform == null) return;

        gameTime += Time.deltaTime;

        if (gameTime >= 120f && currentLevelIndex != 3)
        {
            currentLevel = level3;
            currentLevelIndex = 3;

            levelText.text = "Level 3";

            Debug.Log("Level 3 시작!");
        }
        else if (gameTime >= 60f && currentLevelIndex != 2)
        {
            currentLevel = level2;
            currentLevelIndex = 2;

            levelText.text = "Level 2";

            Debug.Log("Level 2 시작!");
        }

        if (Time.time >= nextSpawnTime)
        {
            SpawnMonster();
            nextSpawnTime = Time.time + currentLevel.spawnInterval;
        }
    }

    void SpawnMonster()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);

        Vector3 spawnPosition = playerTransform.position +
                                (Vector3)(randomDirection * randomDistance);

        spawnPosition.x = Mathf.Clamp(spawnPosition.x, minX, maxX);
        spawnPosition.y = Mathf.Clamp(spawnPosition.y, minY, maxY);

        GameObject monster = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);

        Monster monsterScript = monster.GetComponent<Monster>();

        monsterScript.monsterData =
            currentLevel.monsters[
Random.Range(
0,
currentLevel.monsters.Length
)
];
    }
}