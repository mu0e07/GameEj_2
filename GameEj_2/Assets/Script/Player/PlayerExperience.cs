using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour
{
    [Header("레벨")]
    public int level = 1;

    [Header("현재 경험치")]
    public int currentExp = 0;

    [Header("다음 레벨 필요 경험치")]
    public int maxExp = 5;

    [SerializeField] private Slider expBar;

    public void AddExperience(int amount)
    {
        currentExp += amount;

        Debug.Log($"EXP : {currentExp}/{maxExp}");

        if (currentExp >= maxExp)
        {
            LevelUp();
        }
        expBar.value = (float)currentExp / maxExp;
    }

    void LevelUp()
    {
        level++;

        currentExp -= maxExp;

        maxExp += 5;

        Debug.Log("레벨업!");

        UpgradeManager.Instance.ShowUpgrade();
    }
    void Start()
    {
        expBar.value = 0;
    }
}