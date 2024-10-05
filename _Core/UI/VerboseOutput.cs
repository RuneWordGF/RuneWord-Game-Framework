using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VerboseOutput : MonoBehaviour
{
    public TextMeshProUGUI Output;

    public List<string> AllLines = new List<string>();
    public int MaxLines = 10;

    private void Start()
    {
        Output.text = "";
    }

    public void Feed(string newLine)
    {
        AllLines.Add(newLine);
        if (AllLines.Count > MaxLines)
        {
            AllLines = HandleList.SubList<string>(AllLines, 1);
        }
        string textOuput = "";
        foreach (string line in AllLines)
        {
            textOuput += line + "\n";
        }

        Output.text = textOuput;
    }
}
