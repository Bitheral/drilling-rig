using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject controls_menu;
    public GameObject main_menu;

    private void Start()
    {
        controls_menu.SetActive(false);
        main_menu.SetActive(true);
    }

    public void onPlayClicked()
    {
        SceneManager.LoadScene("Game");
    }

    public void onControlsClicked()
    {
        controls_menu.SetActive(true);
        main_menu.SetActive(false);
    }

    public void onQuitClicked()
    {
        Application.Quit();
    }

    public void onControlsBackClicked()
    {
        controls_menu.SetActive(false);
        main_menu.SetActive(true);
    }
}
