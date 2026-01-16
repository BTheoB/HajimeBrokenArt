using System.IO;
using System.Linq;
using UnityEngine;

public class ScorePersistanceManager : MonoBehaviour
{
    public static ScorePersistanceManager Instance { get; private set; }

    private string SavePath => Application.persistentDataPath + "/highscores.json";

    public ScoreData Data { get; private set; } = new();

    private int MaxScoreToKee = 20;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void AddScore(string playerName, int score)
    {
        Data.scores.Add(new ScoreEntry(playerName, score));

        // tri décroissant
        Data.scores = Data.scores
            .OrderByDescending(s => s.score)
            .Take(MaxScoreToKee) // top x scores
            .ToList();

        Save();
    }

    private void Save()
    {
        string json = JsonUtility.ToJson(Data, true);
        File.WriteAllText(SavePath, json);
    }

    private void Load()
    {
        if (!File.Exists(SavePath))
            return;

        string json = File.ReadAllText(SavePath);
        Data = JsonUtility.FromJson<ScoreData>(json);
    }
}
