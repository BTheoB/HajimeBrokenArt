using System;
using UnityEngine;

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public int score;
    public string date;

    public ScoreEntry(string name, int score)
    {
        playerName = name;
        this.score = score;
        this.date = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
    }
}

