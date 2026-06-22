using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Game/Upgrade")]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;

    [TextArea]
    public string description;

    public UpgradeType upgradeType;

    public float value;
}