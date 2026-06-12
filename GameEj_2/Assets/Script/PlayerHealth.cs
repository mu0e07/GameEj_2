using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        // [추가] 시작할 때 UI에 현재 체력 표시
        GameManager.Instance.UpdateHealthUI(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"플레이어 피격! 남은 체력: {currentHealth}");

        // [추가] 피격될 때마다 UI 갱신
        GameManager.Instance.UpdateHealthUI(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("플레이어가 사망했습니다!");
        gameObject.SetActive(false);
    }
}
