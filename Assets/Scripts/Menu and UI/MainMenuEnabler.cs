using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEnabler : MonoBehaviour
{
    public GameObject MainMenu;

    public Animator CreditsAnim;

    public void start()
    {
        if (!CreditsAnim)
        {
            GameObject credits_text = GameObject.Find("Credits Text");
            if (credits_text)
            {
                CreditsAnim = credits_text.GetComponent<Animator>();
            }
            else
            {
                print("cant find credits text");
            }
        }
    }


    public void disableMenu()
    {
        MainMenu.SetActive(false);
    }

    public void enableMenu()
    {
        MainMenu.SetActive(true);
    }

    public void credits()
    {
        if (CreditsAnim)
        {
            CreditsAnim.SetTrigger("Start");
        }
        else
        {
            print("cant find credits anim");
        }
    }
}
