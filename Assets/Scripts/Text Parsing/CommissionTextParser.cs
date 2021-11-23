using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class CommissionTextParser : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI commissionerName;
    [SerializeField] TextMeshProUGUI subjectLine;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI numOfIngredientsText;
    public Image PFPImage; 
    public List<Sprite> commissionerSprites = new List<Sprite>(); 
    public List<string[]> dataSheet = new List<string[]>();
    public int counter = 0;
    public ReputationManager rm;
    private int currentRepLevel;
    private int currentRepProgress;

    public void Start()
    {
        //Get the file, slice it into a list of strings
        string readFromFilePath = Application.dataPath + "/Imported Text Assets/" + "Commission Requests" + ".txt";
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();
        foreach (string line in fileLines)
        {
            string[] content = line.Split('\t');
            dataSheet.Add(content);
        }
        //Draw the initial text
        currentRepLevel = 1;
        currentRepProgress = 0; 
        DrawText();
    }
    public void UpdateReputation()
    {
        if (currentRepProgress != rm.reputationprogress || currentRepLevel != rm.reputationLevel) {
            currentRepLevel = rm.reputationLevel;
            currentRepProgress = rm.reputationprogress;
            counter += 1;
            DrawText();
        }
    }

    
private void DrawText()
    {
        commissionerName.text = dataSheet[counter][1];
        subjectLine.text = dataSheet[counter][2];
        description.text = dataSheet[counter][3];
        numOfIngredientsText.text = getNumOfIngredients().ToString();
        PFPImage.sprite = commissionerSprites[counter]; 
        
    }
    private int getNumOfIngredients()
    {
        if(counter >= 0 && counter <5)
        {
            return 2; //First 5 potions
        }
        else if(counter ==5 || counter == 6)
        {
            return 3; //Melancholy, Good Trip
        }
        else if(counter >=7 && counter <10)
        {
            return 4; //Laganja, Sike, Arnold
        }
        else
        {
            return 8; //Panacea 
        }
    }
}
