using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EncyclopediaChooser : MonoBehaviour
{
    public Button potionButton;
    public Button ingredientsButton;
    public GameObject ingredientsTextUI;
    public GameObject potionTextUI;


    public void Start()
    {
        //Initialize buttons
        Button potion = potionButton.GetComponent<Button>();
        Button ingredients = ingredientsButton.GetComponent<Button>();
        potion.onClick.AddListener(goPotion);
        ingredients.onClick.AddListener(goIngredients);
        goIngredients(); 
    }
    public void goPotion()
    {
        ingredientsTextUI.SetActive(false);
        potionTextUI.SetActive(true);
    }

    public void goIngredients()
    {
        ingredientsTextUI.SetActive(true);
        potionTextUI.SetActive(false);
    }
}
