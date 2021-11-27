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

    public void Awake()
    {
        //Get the file, slice it into a list of strings
        string readFromFilePath = Path.Combine(Application.streamingAssetsPath, "Commission Requests.txt");
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();
        foreach (string line in fileLines)
        {
            string[] content = line.Split('\t');
            dataSheet.Add(content);
        }
        //Draw the initial text
        counter = 0;
        Debug.Log("Counter at init: " + counter);
        DrawText();
    }

    public void DrawText()
    {  
        counter = 2 * rm.reputationLevel + rm.reputationprogress - 2;
        Debug.Log("Reputation Level:" + rm.reputationLevel);
        Debug.Log("Reputation Progress:" + rm.reputationprogress); 
        Debug.Log("Counter after DrawText: " + counter);
        commissionerName.text = dataSheet[counter][0];
        subjectLine.text = dataSheet[counter][1];
        description.text = dataSheet[counter][2];
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
