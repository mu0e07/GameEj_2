using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject currentBulletPrefab;
    [Header("캐릭터별 무기")]
    [SerializeField] private GameObject redKnife;
    [SerializeField] private GameObject yellowKnife;
    [SerializeField] private GameObject blueKnife;

    [SerializeField] private GameObject greenFireball;
    [SerializeField] private GameObject blackFireball;
    [SerializeField] private GameObject whiteFireball;

    [SerializeField] private float scanRange = 10f;

    private float lastAttackTime;
    private PlayerStats stats;

    void Update()
    {
        if (Time.time >= lastAttackTime + stats.attackSpeed)
        {
            Transform targetMonster = FindClosestMonster();

            if (targetMonster != null)
            {
                FireBullet(targetMonster);
                lastAttackTime = Time.time;
            }
        }
    }

    Transform FindClosestMonster()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        Transform closestMonster = null;
        float closestDistance = scanRange;

        foreach (GameObject monster in monsters)
        {
            float distance = Vector2.Distance(transform.position, monster.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestMonster = monster.transform;
            }
        }
        return closestMonster;
    }

    void FireBullet(Transform target)
    {
        GameObject bulletObj =
    Instantiate(currentBulletPrefab,
                transform.position,
                Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        if (bullet != null)
        {
            Vector2 dir = (target.position - transform.position).normalized;

            // 방향 + 공격력 전달
            bullet.SetDirection(dir, stats.attack);
        }
    }
    void Start()
    {
        stats = GetComponent<PlayerStats>();

        int character = CharacterSelection.SelectedCharacter;

        switch (character)
        {
            case 0:
                currentBulletPrefab = redKnife;
                break;

            case 1:
                currentBulletPrefab = yellowKnife;
                break;

            case 2:
                currentBulletPrefab = blueKnife;
                break;

            case 3:
                currentBulletPrefab = greenFireball;
                break;

            case 4:
                currentBulletPrefab = blackFireball;
                break;

            case 5:
                currentBulletPrefab = whiteFireball;
                break;

            default:
                currentBulletPrefab = redKnife;
                break;
                Debug.Log("선택 캐릭터 번호 : " + CharacterSelection.SelectedCharacter);
                Debug.Log("현재 무기 : " + currentBulletPrefab);
        }
    }
}
