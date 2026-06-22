using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerStats stats;



    void Start()
    {
        stats = GetComponent<PlayerStats>();

        stats.currentHP = stats.maxHP;

        GameManager.Instance.UpdateHealthUI(stats.currentHP);
    }

    public void TakeDamage(int damage)
    {
        stats.currentHP -= damage;

        Debug.Log($"플레이어 피격! 남은 체력 : {stats.currentHP}");

        GameManager.Instance.UpdateHealthUI(stats.currentHP);

        if (stats.currentHP <= 0)
        {
            Die();
        }

        void Die()
        {
            Debug.Log("플레이어가 사망했습니다!");
            gameObject.SetActive(false);
        }
    }
    public void IncreaseMaxHP(int amount)
    {
        stats.maxHP += amount;
        stats.currentHP += amount;

        GameManager.Instance.UpdateHealthUI(stats.currentHP);

        Debug.Log($"최대 체력 증가! 현재 {stats.currentHP}/{stats.maxHP}");
    }
}
