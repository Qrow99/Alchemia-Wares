using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class ReputationUI : MonoBehaviour
{
    //Bottle sprites to show and hide 
    public Image FullBottle1;
    public Image HalfBottle1;
    public Image FullBottle2;
    public Image HalfBottle2;
    public Image FullBottle3;
    public Image HalfBottle3;
    public Image FullBottle4;
    public Image HalfBottle4;
    public Image FullBottle5;
    public Image HalfBottle5;

    //Next ingredients text to show and hide
    [SerializeField] TextMeshProUGUI IngredientLevel1;
    [SerializeField] TextMeshProUGUI IngredientLevel2;
    [SerializeField] TextMeshProUGUI IngredientLevel3;
    [SerializeField] TextMeshProUGUI IngredientLevel4;

    //Buttons
    public Button ProfileButton;
    public Button BackButton;

    //Rep manager
    public ReputationManager rm;

    //Profile subwindow
    public GameObject ProfileSubwindow; 

    private void Start()
    {
        ProfileButton.onClick.AddListener(goToProfile);
        BackButton.onClick.AddListener(goBack);
    }

    private void goToProfile()
    {
        gameObject.SetActive(false);
        ProfileSubwindow.SetActive(true);

    }

    private void goBack()
    {
        gameObject.SetActive(true);
        ProfileSubwindow.SetActive(false);
    }

    public void UpdateReputation()
    {
        UpdateNextIngredients();
        UpdatePotionBottles();
    }

    private void UpdateNextIngredients()
    {
        if(rm.reputationLevel == 1)
        {
            IngredientLevel1.gameObject.SetActive(true);
        }
        else if(rm.reputationLevel == 2)
        {
            IngredientLevel1.gameObject.SetActive(false);
            IngredientLevel2.gameObject.SetActive(true);
        }
        else if(rm.reputationLevel == 3)
        {
            IngredientLevel2.gameObject.SetActive(false);
            IngredientLevel3.gameObject.SetActive(true);
        }
        else
        {
            IngredientLevel3.gameObject.SetActive(false);
            IngredientLevel4.gameObject.SetActive(true); 
        }
    }

    private void UpdatePotionBottles()
    {
        int level = rm.reputationLevel;
        int prog = rm.reputationprogress;
        if(level == 2 && prog == 1)
        {
            HalfBottle1.gameObject.SetActive(true);
        }
        else if(level == 3 && prog == 0)
        {
            HalfBottle1.gameObject.SetActive(false);
            FullBottle1.gameObject.SetActive(true);
        }
        else if (level == 3 && prog == 1)
        {
            HalfBottle2.gameObject.SetActive(true);
        }
        else if (level == 4 && prog == 0)
        {
            HalfBottle2.gameObject.SetActive(false);
            FullBottle2.gameObject.SetActive(true);
        }
        else if (level == 4 && prog == 1)
        {
            HalfBottle3.gameObject.SetActive(true);
        }
        else if (level == 5 && prog == 0)
        {
            HalfBottle3.gameObject.SetActive(false);
            FullBottle3.gameObject.SetActive(true);
        }
        else if (level == 5 && prog == 1)
        {
            HalfBottle4.gameObject.SetActive(true);
        }
        else if (level == 6 && prog == 0)
        {
            HalfBottle4.gameObject.SetActive(false);
            FullBottle4.gameObject.SetActive(true);
        }
        else if (level == 6 && prog == 1)
        {
            HalfBottle5.gameObject.SetActive(true);
        }
        else if (level == 6 && prog == 2)
        {
            HalfBottle5.gameObject.SetActive(false);
            FullBottle5.gameObject.SetActive(true);
        }
        else
        {
            return; 
        }    

    }
}
