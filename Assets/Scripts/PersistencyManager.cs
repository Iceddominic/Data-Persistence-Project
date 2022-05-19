using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistencyManager : MonoBehaviour
{
    public static PersistencyManager Instance;

    public string currentPlayerName;
    public string highscorePlayerName;
    public int highscoreScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighscore();
    }

    [System.Serializable]
    class SaveData
    {
        public string currentPlayerName;
        public string highscorePlayerName;
        public int highscoreScore;
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.currentPlayerName = currentPlayerName;
        data.highscorePlayerName = highscorePlayerName;
        data.highscoreScore = highscoreScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            currentPlayerName = data.currentPlayerName;
            highscorePlayerName = data.highscorePlayerName;
            highscoreScore = data.highscoreScore;
        }
    }
}
