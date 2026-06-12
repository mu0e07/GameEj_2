using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private float spawnInterval = 1f;

    [Header("소환 거리 설정 (플레이어 기준)")]
    [SerializeField] private float minSpawnDistance = 5f;
    [SerializeField] private float maxSpawnDistance = 10f;

    [Header("맵 가로/세로 제한 크기 (맵 중심이 0,0 일 때)")]
    [SerializeField] private float minX = -15f; // 왼쪽 벽 X 좌표
    [SerializeField] private float maxX = 15f;  // 오른쪽 벽 X 좌표
    [SerializeField] private float minY = -15f; // 아래쪽 벽 Y 좌표
    [SerializeField] private float maxY = 15f;  // 위쪽 벽 Y 좌표

    private Transform playerTransform;
    private float nextSpawnTime;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        if (Time.time >= nextSpawnTime)
        {
            SpawnMonster();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnMonster()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        Vector3 spawnPosition = playerTransform.position + (Vector3)(randomDirection * randomDistance);

        // [핵심] 계산된 스폰 위치가 맵 밖을 벗어나지 못하도록 가두기 (Clamp)
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, minX, maxX);
        spawnPosition.y = Mathf.Clamp(spawnPosition.y, minY, maxY);

        Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
    }
}