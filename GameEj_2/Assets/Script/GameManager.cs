using UnityEngine;
using TMPro; // TextMesh Pro를 사용하기 위해 필수 포함

public class GameManager : MonoBehaviour
{
    // 싱글톤(Singleton) 패턴: 어디서나 GameManager에 쉽게 접근할 수 있도록 함
    public static GameManager Instance { get; private set; }

    [Header("UI 연결")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;

    void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreUI();
    }

    // 체력 UI를 갱신하는 함수 (PlayerHealth에서 호출할 예정)
    public void UpdateHealthUI(int currentHealth)
    {
        if (healthText != null)
        {
            healthText.text = $"HP: {currentHealth}";
        }
    }

    // 점수를 추가하고 UI를 갱신하는 함수 (MonsterAI에서 호출할 예정)
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }
}