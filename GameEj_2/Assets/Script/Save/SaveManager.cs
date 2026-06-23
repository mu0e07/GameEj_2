using UnityEngine;
using System.IO;

public class JsonSaveManager : MonoBehaviour
{
    public static JsonSaveManager Instance;

    private string savePath;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        savePath = Application.persistentDataPath + "/save.json";
    }

    public void SaveGame(int score)
    {
        SaveData data = new SaveData();

        data.score = score;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(savePath, json);

        Debug.Log("저장 완료 : " + savePath);
    }

    public SaveData LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Debug.Log("불러오기 완료");

            return data;
        }

        return null;
    }
}