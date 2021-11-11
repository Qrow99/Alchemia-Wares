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
    public int counter = 0; //Essentially just page number
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
    //LINK THIS UP WITH REP SYSTEM
    public void GoNext()
    {
        if(counter < dataSheet.Count()/2-1)
        {
            counter += 1;
            DrawText(); 
        }
    }
    public void GoPrev()
    {
        if (counter > 0)
        {
            counter -= 1;
            DrawText(); 
        }
    }
    private void DrawText()
    {
        ingredientName1.text = dataSheet[counter][0];
        shortDesc1.text = dataSheet[counter][1];
        longDesc1.text = dataSheet[counter][2];
        processingMethod1.text = dataSheet[counter][3];

        ingredientName2.text = dataSheet[counter + 1][0];
        shortDesc2.text = dataSheet[counter + 1][1];
        longDesc2.text = dataSheet[counter + 1][2];
        processingMethod2.text = dataSheet[counter + 1][3];
    }
    
}
