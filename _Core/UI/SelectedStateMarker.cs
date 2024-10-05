using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectedStateMarker : MonoBehaviour
{
    public RWUF_Button InteractableButton;
    public GameObject HighlightSample;
    private GameObject generatedHighlight;

    public bool OnPointerHighlight;

    private void Start()
    {
        InteractableButton = GetComponent<RWUF_Button>();

        if (OnPointerHighlight)
        {
            InteractableButton.OnPointerEnterEvent.AddListener(() => SetMarkedItem(true));
            InteractableButton.OnPointerExitEvent.AddListener(() => SetMarkedItem(false));
        }
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
