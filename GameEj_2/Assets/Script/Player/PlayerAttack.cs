using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
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
        GameObject bulletObj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
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
    }
}
