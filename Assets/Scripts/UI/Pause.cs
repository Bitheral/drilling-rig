using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject controls_menu;
    public GameObject pause_menu;
    public GameObject canvas;

    public bool isPaused = false;

    private void Start()
    {
        controls_menu.SetActive(false);
        pause_menu.SetActive(true);

        canvas = transform.gameObject;
    }

    public void onResumeClicked()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    public void onControlsClicked()
    {
        controls_menu.SetActive(true);
        pause_menu.SetActive(false);
    }

    public void onQuitDesktopClicked()
    {
        Application.Quit();
    }

    public void onQuitMainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void onControlsBackClicked()
    {
        controls_menu.SetActive(false);
        pause_menu.SetActive(true);
    }
}
