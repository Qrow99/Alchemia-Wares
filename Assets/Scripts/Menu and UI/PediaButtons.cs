using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PediaButtons : MonoBehaviour
{
    public static bool isPedia = false;
    public GameObject PediaUI;

    public void Start()
    {
        PediaUI.SetActive(false);
    }
    public void open()
    {
        PediaUI.SetActive(true);
        Time.timeScale = 0;
        isPedia = true;
    }

    public void close()
    {
        PediaUI.SetActive(false);
        Time.timeScale = 1;
        isPedia = false;
    }
}
