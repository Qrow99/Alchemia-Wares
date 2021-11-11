using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerUIManager : MonoBehaviour
{
    public GameObject computerScreen;
    public int current_commision;
    // Start is called before the first frame update
    void Start()
    {
        disableScreen();
        current_commision = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableScreen()
    {
        computerScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        if(current_commision == 1) //activate the UI elements relating to the first commission
        {

        }
    }

    public void disableScreen()
    {
        computerScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
