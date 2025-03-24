using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject holder;
    [SerializeField] private Button unpauseButton;
    [SerializeField] private Button quitButton;
    void Start()
    {
        Globals.OnPauseChanged += OnPauseChanged;
        unpauseButton.onClick.AddListener(OnUnpause);
        quitButton.onClick.AddListener(OnQuit);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!Globals.IsPaused)
                Globals.SetPause(true);
            else
            {
                OnUnpause();
            }
        }
    }

    private void OnPauseChanged(bool isPaused)
    {
        if (isPaused)
        {
            holder.SetActive(true);
        }
    }

    private void OnUnpause()
    {
        Globals.SetPause(false);
        holder.SetActive(false);
    }

    private void OnQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
