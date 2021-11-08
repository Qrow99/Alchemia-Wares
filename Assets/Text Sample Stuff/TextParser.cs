using System.Collections;
using System.Collections.Generic;
using System.IO; 
using UnityEngine;
using System.Linq; 
using UnityEngine.UI;
using TMPro; 

public class TextParser : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ingredientName;
    [SerializeField] TextMeshProUGUI shortDesc;
    [SerializeField] TextMeshProUGUI longDesc;
    [SerializeField] TextMeshProUGUI processingMethod;
    public Button prevButton;
    public Button nextButton; 
    public List<string[]> dataSheet = new List<string[]>();
    public int counter = 0; 
    public void Start()
    {
        Button next = nextButton.GetComponent<Button>();
        Button prev = prevButton.GetComponent<Button>();
        next.onClick.AddListener(GoNext);
        prev.onClick.AddListener(GoPrev); 
        string readFromFilePath = Application.dataPath + "/Text Sample Stuff/" + "Ingredient Descriptions - Sheet1" + ".txt";
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();
        foreach(string line in fileLines)
        {
            string[] content = line.Split('\t');
            dataSheet.Add(content); 
        }
        ingredientName.text = dataSheet[counter][0];
        shortDesc.text = dataSheet[counter][1];
        longDesc.text = dataSheet[counter][2];
        processingMethod.text = dataSheet[counter][3];
    }
    public void GoNext()
    {
        print("next");
        if(counter < dataSheet.Count()-1)
        {
            counter += 1;
            ingredientName.text = dataSheet[counter][0];
            shortDesc.text = dataSheet[counter][1];
            longDesc.text = dataSheet[counter][2];
            processingMethod.text = dataSheet[counter][3];
        }
    }
    public void GoPrev()
    {
        print("prev");
        if (counter > 0)
        {
            counter -= 1;
            ingredientName.text = dataSheet[counter][0];
            shortDesc.text = dataSheet[counter][1];
            longDesc.text = dataSheet[counter][2];
            processingMethod.text = dataSheet[counter][3];
        }
    }
    
}
