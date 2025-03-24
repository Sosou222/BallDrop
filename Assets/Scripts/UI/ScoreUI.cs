using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    void Start()
    {
        Globals.OnScoreChanged += UpdateText;
    }

    private void UpdateText(int score)
    {
        text.text = "Score:" + score;
    }
}
