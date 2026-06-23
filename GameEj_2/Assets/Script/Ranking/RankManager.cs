using UnityEngine;
using System.Collections.Generic;

public static class RankManager
{
    const string KEY = "Ranking";

    public static List<int> Load()
    {
        string data = PlayerPrefs.GetString(KEY, "");

        List<int> scores = new List<int>();

        if (data == "")
            return scores;

        string[] split = data.Split(',');

        foreach (string s in split)
        {
            scores.Add(int.Parse(s));
        }

        return scores;
    }

    public static void SaveScore(int newScore)
    {
        List<int> scores = Load();

        scores.Add(newScore);

        scores.Sort((a, b) => b.CompareTo(a));

        if (scores.Count > 10)
        {
            scores.RemoveRange(10, scores.Count - 10);
        }

        string saveData = string.Join(",", scores);

        PlayerPrefs.SetString(KEY, saveData);
        PlayerPrefs.Save();
    }
}