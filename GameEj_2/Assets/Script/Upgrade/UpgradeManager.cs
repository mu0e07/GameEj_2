using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    [SerializeField] private GameObject levelUpPanel;

    [SerializeField] private UpgradeButton[] buttons;

    [SerializeField] private UpgradeData[] upgrades;

    private PlayerStats playerStats;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public void ShowUpgrade()
    {
        Time.timeScale = 0;

        levelUpPanel.SetActive(true);

        for (int i = 0; i < buttons.Length; i++)
        {
            UpgradeData randomUpgrade = upgrades[Random.Range(0, upgrades.Length)];
            buttons[i].SetUpgrade(randomUpgrade);
        }
    }

    public void CloseUpgrade()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void ApplyUpgrade(UpgradeData data)
    {
        switch (data.upgradeType)
        {
            case UpgradeType.Attack:
                playerStats.attack += (int)data.value;
                break;

            case UpgradeType.AttackSpeed:
                playerStats.attackSpeed -= data.value * 0.01f;
                break;

            case UpgradeType.MaxHP:
                PlayerHealth health = FindFirstObjectByType<PlayerHealth>();

                if (health != null)
                {
                    health.IncreaseMaxHP((int)data.value);
                }
                break;

            case UpgradeType.MoveSpeed:
                playerStats.moveSpeed += data.value;
                break;
        }

        CloseUpgrade();
    }
}