using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtons : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject PauseUI;

    public void Start()
    {
        PauseUI.SetActive(false);
    }
    public void pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
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
