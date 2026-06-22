using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    private UpgradeData data;

    public void SetUpgrade(UpgradeData upgrade)
    {
        data = upgrade;

        titleText.text = upgrade.upgradeName;
        descriptionText.text = upgrade.description;
    }

    public void OnClick()
    {
        UpgradeManager.Instance.ApplyUpgrade(data);
    }
}
