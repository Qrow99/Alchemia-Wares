using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ComputerWindowChooser : MonoBehaviour
{
    public Button commissionsButton;
    public Button reputationButton;
    public GameObject commissionSubwindow;
    public GameObject reputationSubwindow; 
    void Start()
    {
        //Initialize the buttons 
        commissionsButton.onClick.AddListener(goCommission);
        reputationButton.onClick.AddListener(goReputation);
        goCommission(); 
    }

    private void goCommission()
    {
        commissionSubwindow.SetActive(true);
        reputationSubwindow.SetActive(false);
    }
    private void goReputation()
    {
        commissionSubwindow.SetActive(false);
        reputationSubwindow.SetActive(true); 
    }
}
