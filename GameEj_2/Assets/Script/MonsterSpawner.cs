using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private float spawnInterval = 3f;

    [Header("소환 거리 설정")]
    [SerializeField] private float minSpawnDistance = 5f;
    [SerializeField] private float maxSpawnDistance = 10f;

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
            Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
        }
}
