using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals
{
    public delegate void ScoreChanged(int score);
    public static event ScoreChanged OnScoreChanged;

    private static int score = 0;

    public static void AddToScore(int add)
    {
        score += add;
        OnScoreChanged?.Invoke(score);
    }

    public static void ClearScore()
    {
        score = 0;
        OnScoreChanged?.Invoke(score);
    }
}
