using System.Collections;
using System.Collections.Generic;
using System.IO; 
using UnityEngine;
using System.Linq; 
using UnityEngine.UI;
using TMPro; 

public class IngredientTextParser : MonoBehaviour
{
    //Witchipedia displays 2 ingredients per page
    [SerializeField] TextMeshProUGUI ingredientName1;
    [SerializeField] TextMeshProUGUI shortDesc1;
    [SerializeField] TextMeshProUGUI longDesc1;
    [SerializeField] TextMeshProUGUI processingMethod1;

    [SerializeField] TextMeshProUGUI ingredientName2;
    [SerializeField] TextMeshProUGUI shortDesc2;
    [SerializeField] TextMeshProUGUI longDesc2;
    [SerializeField] TextMeshProUGUI processingMethod2;
    public Button prevButton;
    public Button nextButton; 
    public List<string[]> dataSheet = new List<string[]>(); //Imported text goes here
    public int currentPage = 0; //Essentially just page number
    public ReputationManager rm; 
    public void Awake()
    {
        //Initialize the buttons
        nextButton.onClick.AddListener(GoNext);
        prevButton.onClick.AddListener(GoPrev);
        prevButton.gameObject.SetActive(false);
        //Get the file, slice it into a list of strings
        string readFromFilePath = Application.dataPath + "/Imported Text Assets/" + "Ingredient Descriptions" + ".txt";
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();
        foreach(string line in fileLines)
        {
            string[] content = line.Split('\t');
            dataSheet.Add(content); 
        }

        //Draw the initial text
        DrawText(); 
    }
    public void UpdateIngredients(int repLevel)
    {
        
    }

    public void GoNext() {
        // if prevButton isn't active, always set it to active when you click nextButton
        if (!prevButton.gameObject.activeSelf) {
            prevButton.gameObject.SetActive(true);
        }
        if (currentPage < 3) {
            currentPage += 1;
            DrawText();
            // if we are at the last page, set the nextButton to inactive
            if (currentPage == 3) {
                nextButton.gameObject.SetActive(false);
            }
        }
    }
    public void GoPrev() {
        // if nextButton isn't active, always set it to active when you click prevButton
        if (!nextButton.gameObject.activeSelf) {
            nextButton.gameObject.SetActive(true);
        }
        if (currentPage > 0) {
            currentPage -= 1;
            DrawText();
            // if we are at the first page, set the prevButton to inactive
            if (currentPage == 0) {
                prevButton.gameObject.SetActive(false);
            }
        }
    }

    private void DrawText()
    {
            ingredientName1.text = dataSheet[currentPage*2][0];
            shortDesc1.text = dataSheet[currentPage*2][1];
            longDesc1.text = dataSheet[currentPage*2][2];
            processingMethod1.text = dataSheet[currentPage*2][3];

            ingredientName2.text = dataSheet[currentPage*2 + 1][0];
            shortDesc2.text = dataSheet[currentPage*2 + 1][1];
            longDesc2.text = dataSheet[currentPage*2 + 1][2];
            processingMethod2.text = dataSheet[currentPage*2 + 1][3];
    }
    
}
