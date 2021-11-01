using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Test Scene");
    }

    public void quit()
    {
        print("quit");
        Application.Quit();
    }
}
