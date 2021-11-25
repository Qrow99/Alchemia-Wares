using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerUIManager : MonoBehaviour
{
    public GameObject computerScreen;
    public int current_commision;
    public CommissionTextParser commissions;
    public ReputationUI ru; 
    // Start is called before the first frame update
    void Start()
    {
        disableScreen();
        current_commision = 1;
        //commissions = FindObjectOfType<CommissionTextParser>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableScreen()
    {
        computerScreen.SetActive(true);
        FindObjectOfType<AudioManager>().Play("mouse_click_raw2");
        Cursor.lockState = CursorLockMode.Confined;
        ru.UpdateReputation(); 
        commissions.DrawText();
    }

    public void disableScreen()
    {
        computerScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

    }
}
