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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
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
        currentHealth -= damage;
        Debug.Log($"���� �ǰ�! ���� ü��: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("몬스터가 소멸했습니다.");

        // [추가] 몬스터가 죽을 때 점수 100점 추가 (원하는 점수로 변경 가능)
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(100);
        }

        Destroy(gameObject);
    }
}
