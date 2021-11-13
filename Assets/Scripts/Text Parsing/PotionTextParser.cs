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
    public ReputationManager rm; 
    public void Start()
    {
        //Initialize the buttons
        Button next = nextButton.GetComponent<Button>();
        Button prev = prevButton.GetComponent<Button>();
        next.onClick.AddListener(GoNext);
        prev.onClick.AddListener(GoPrev);
        //Get the file, slice it into a list of strings
        string readFromFilePath = Application.dataPath + "/Imported Text Assets/" + "Potion Descriptions" + ".txt";
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
        if (currentPage < 10)
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
        potionName.text = dataSheet[currentPage][0];
        shortDesc.text = dataSheet[currentPage][1];
        longDesc.text = dataSheet[currentPage][2];
        potionEquation.text = dataSheet[currentPage][3];
    }
    private void ShowHideButtons()
    {

    }

}
