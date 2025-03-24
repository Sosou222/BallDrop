using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Globals;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject holder;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button quitButton;
    void Start()
    {
        retryButton.onClick.AddListener(OnRetry);
        quitButton.onClick.AddListener(OnQuit);
        Globals.OnGameOver += OnGameOver;
    }

    private void OnDestroy()
    {
        Globals.OnGameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        holder.SetActive(true);
    }

    private void OnRetry()
    {
        Globals.SetGameover(false);
        Globals.ClearScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
