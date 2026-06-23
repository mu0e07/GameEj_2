using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class RankingUI : MonoBehaviour
{
    public TextMeshProUGUI[] rankTexts;

    void Start()
    {
        List<int> scores = RankManager.Load();

        for (int i = 0; i < rankTexts.Length; i++)
        {
            if (i < scores.Count)
            {
                rankTexts[i].text =
                    (i + 1) + "위 : " + scores[i];
            }
            else
            {
                rankTexts[i].text =
                    (i + 1) + "위 : -";
            }
        }
    }
}
