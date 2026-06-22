using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("�̵� ����")]
    [SerializeField] private float moveSpeed = 2f;

    [Header("ü�� ����")]
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;

    [Header("���� ����")]
    [SerializeField] private int damageToPlayer = 1;
    [SerializeField] private float attackCooldown = 1f;
    private float lastAttackTime;

    private Transform playerTransform;
    private Rigidbody2D rb;
    [SerializeField] private GameObject experiencePrefab;

    public MonsterData monsterData;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = monsterData.maxHP;
        moveSpeed = monsterData.moveSpeed;
        damageToPlayer = monsterData.attack;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        GetComponent<SpriteRenderer>().sprite = monsterData.sprite;
    }

    private void FixedUpdate()
    {
        if (playerTransform != null && playerTransform.gameObject.activeSelf)
        {
            Vector2 direction = ((Vector2)playerTransform.position - rb.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageToPlayer);
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("받은 데미지 : " + damage);

        currentHealth -= damage;

        Debug.Log("남은 체력 : " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("몬스터 사망");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(monsterData.score);
        }

        PlayerExperience exp = FindFirstObjectByType<PlayerExperience>();
        if (exp != null)
        {
            exp.AddExperience(monsterData.exp);
        }

        Destroy(gameObject);
    }
}