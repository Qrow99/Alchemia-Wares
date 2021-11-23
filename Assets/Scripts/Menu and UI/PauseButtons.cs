using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtons : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject PauseUI;
    public GameObject Crosshair;

    public void Start()
    {
        PauseUI.SetActive(false);
    }
    public void pause()
    {
        Crosshair.SetActive(false);
        PauseUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        Crosshair.SetActive(true);
        Time.timeScale = 1;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void quit()
    {
        print("quit");
        Application.Quit();
    }
}
