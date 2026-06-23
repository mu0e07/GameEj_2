using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject rankingPanel;

    public void OpenRanking()
    {
        rankingPanel.SetActive(true);
    }

    public void CloseRanking()
    {
        rankingPanel.SetActive(false);
    }
}

