using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class PotionTextParser : MonoBehaviour
{
    //Basically identical to ingredient text parser
    [SerializeField] TextMeshProUGUI potionName;
    [SerializeField] TextMeshProUGUI shortDesc;
    [SerializeField] TextMeshProUGUI longDesc;
    [SerializeField] TextMeshProUGUI potionEquation;

    public Button prevButton;
    public Button nextButton;
    public List<string[]> dataSheet = new List<string[]>();
    public int currentPage = 0; //Essentially just page number
    public bool[] potionsFound;
    public ReputationManager rm; 
    public void Awake()
    {
        //Initialize the buttons
        nextButton.onClick.AddListener(GoNext);
        prevButton.onClick.AddListener(GoPrev);
        prevButton.gameObject.SetActive(false);
        //Get the file, slice it into a list of strings
        string readFromFilePath = Path.Combine(Application.streamingAssetsPath, "Potion Descriptions.txt");
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();
        foreach (string line in fileLines)
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
        // if prevButton isn't active, always set it to active when you click nextButton
        if (!prevButton.gameObject.activeSelf) {
            prevButton.gameObject.SetActive(true);
        }
        if (currentPage < 10)
        {
            currentPage += 1;
            DrawText();
            // if we are at the last page, set the nextButton to inactive
            if(currentPage == 10) {
                nextButton.gameObject.SetActive(false);
            }
        } 
    }
    public void GoPrev()
    {
        // if nextButton isn't active, always set it to active when you click prevButton
        if (!nextButton.gameObject.activeSelf) {
            nextButton.gameObject.SetActive(true);
        }
        if (currentPage > 0)
        {
            currentPage -= 1;
            DrawText();
            // if we are at the first page, set the prevButton to inactive
            if(currentPage == 0) {
                prevButton.gameObject.SetActive(false);
            }
        }
    }

    public void updatePotionFound(int index) {
        potionsFound[index] = true;
    }
    public void DrawText()
    {
        Debug.Log(currentPage);
        if(potionsFound[currentPage] == false) {
            potionName.text = "???";
            shortDesc.text = "???";
            longDesc.text = "???";
            potionEquation.text = "???";
        } else {
            potionName.text = dataSheet[currentPage][0];
            shortDesc.text = dataSheet[currentPage][1];
            longDesc.text = dataSheet[currentPage][2];
            potionEquation.text = dataSheet[currentPage][3];
        }
        
    }

}
