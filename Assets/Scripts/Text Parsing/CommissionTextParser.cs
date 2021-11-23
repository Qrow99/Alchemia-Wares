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
    [SerializeField] public List<string[]> dataSheet = new List<string[]>();
    public ReputationManager rm;
    public int counter;

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
        counter = 0;
        DrawText();
    }

    public void DrawText()
    {
        counter = (2 * rm.reputationLevel) + rm.reputationprogress - 2;
        commissionerName.text = dataSheet[counter][1];
        subjectLine.text = dataSheet[counter][2];
        description.text = dataSheet[counter][3];
        numOfIngredientsText.text = getNumOfIngredients().ToString();
        PFPImage.sprite = commissionerSprites[counter];
    }

    private int getNumOfIngredients()
    {
        if(counter >= 0 && counter < 5)
        {
            return 2; //First 5 potions
        }
        else if(counter == 5 || counter == 6)
        {
            return 3; //Melancholy, Good Trip
        }
        else if(counter >= 7 && counter < 10)
        {
            return 4; //Laganja, Sike, Arnold
        }
        else
        {
            return 8; //Panacea 
        }
    }
}
