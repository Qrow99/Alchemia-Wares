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
    public List<string[]> dataSheet = new List<string[]>();
    public int currentPage = 0; //Essentially just page number
    public ReputationManager rm; 
    public void Start()
    {
        //Initialize the buttons
        Button next = nextButton.GetComponent<Button>();
        Button prev = prevButton.GetComponent<Button>();
        next.onClick.AddListener(GoNext);
        prev.onClick.AddListener(GoPrev);
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
    public void Update()
    {
        ShowHideButtons();
    }
    public void GoNext()
    {
        if(currentPage < 3)
        {
            currentPage += 1;
            DrawText(); 
        }
    }
    public void GoPrev()
    {
        if (currentPage > 0)
        {
            currentPage -= 1;
            DrawText(); 
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
    private void ShowHideButtons() //Shows and hides buttons based on current reputation level. 
    {
        if(currentPage == 0 && rm.reputationLevel == 1 && rm.reputationprogress == 0) //Initial state
        {
            prevButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
        }
        else if(rm.reputationLevel == 2 && rm.reputationprogress == 0) //First 2 ingredients unlocked
        {
            if (currentPage == 0)
            {
                nextButton.gameObject.SetActive(true);
                prevButton.gameObject.SetActive(false);
            }
            else //On page 1, prevent going to next page but allow going to previous page
            {
                nextButton.gameObject.SetActive(false);
                prevButton.gameObject.SetActive(true);
            }
        }
        else if(rm.reputationLevel == 3 && rm.reputationprogress == 0)
        {
            if (currentPage == 0)
            {
                nextButton.gameObject.SetActive(true);
                prevButton.gameObject.SetActive(false);
            }
            else if (currentPage == 1)
            {
                nextButton.gameObject.SetActive(true);
                prevButton.gameObject.SetActive(true);
            }
            else
            {
                nextButton.gameObject.SetActive(false);
                prevButton.gameObject.SetActive(true);
            }
        }
        else
        {
            if (currentPage == 0)
            {
                nextButton.gameObject.SetActive(true);
                prevButton.gameObject.SetActive(false);
            }
            else if (currentPage == 1 || currentPage == 2)
            {
                nextButton.gameObject.SetActive(true);
                prevButton.gameObject.SetActive(true);
            }
            else
            {
                nextButton.gameObject.SetActive(false);
                prevButton.gameObject.SetActive(true);
            }
        }
    }
}
