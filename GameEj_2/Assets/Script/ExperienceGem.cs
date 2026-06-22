using UnityEngine;

public class ExperienceGem : MonoBehaviour
{
    [Header("경험치")]
    public int expAmount = 1;

    [Header("흡수 설정")]
    [SerializeField] private float detectRange = 3f;
    [SerializeField] private float moveSpeed = 8f;

    private Transform player;
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }
    void Update()
    {
        if (player == null)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectRange)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerExperience exp =
                collision.GetComponent<PlayerExperience>();

            if (exp != null)
            {
                exp.AddExperience(expAmount);
            }

            Destroy(gameObject);
        }
    }
}
