using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedStateMarker : MonoBehaviour
{
    public Button InteractableButton;
    public GameObject HighlightSample;
    private GameObject generatedHighlight;

    private void Start()
    {
        InteractableButton = GetComponent<Button>();
    }

    public void SetMarkedItem(bool selected)
    {
        if (!generatedHighlight)
        {
            GenerateHighlightInstance();
        }
        generatedHighlight.SetActive(selected);
    }

    private void GenerateHighlightInstance()
    {
        generatedHighlight = Instantiate(HighlightSample, transform);
        generatedHighlight.transform.SetAsFirstSibling();
    }
}
