using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    void Start()
    {
        playButton.onClick.AddListener(OnPlay);
        quitButton.onClick.AddListener(OnQuit);
    }

    private void OnPlay()
    {
        Globals.ClearScore();
        Globals.SetPause(false);
        Globals.SetGameover(false);
        SceneManager.LoadScene("SampleScene");
    }

    private void OnQuit()
    {
        Application.Quit();
    }
}
