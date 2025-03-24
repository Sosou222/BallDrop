using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals
{
    public delegate void ScoreChanged(int score);
    public static event ScoreChanged OnScoreChanged;

    public delegate void GameOver();
    public static event GameOver OnGameOver;

    public delegate void PauseChanged(bool pause);
    public static event PauseChanged OnPauseChanged;

    private static int score = 0;
    public static bool IsGameOver = false;
    public static bool IsPaused = false;

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

    public static void SetGameover(bool gameOver)
    {
        IsGameOver = gameOver;
        if(IsGameOver == true)
        {
            OnGameOver?.Invoke();
        }
    }

    public static void SetPause(bool pause)
    {
        IsPaused = pause;
        OnPauseChanged?.Invoke(IsPaused);
    }
}
