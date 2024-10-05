using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandsMenu : MonoBehaviour
{
    public InputBridge Inputs;

    private Selectable _selectedItem;

    private void Start()
    {
        if (!Inputs)
        {
            Inputs = FindObjectOfType<InputBridge>();
        }

        Inputs.OnMoving.AddListener((args) => ManageSelection(args));
        Inputs.OnConfirm.AddListener(() => ConfirmSelection());

        Inputs.OnLooking.AddListener((args) => ResetSelection());
    }

    private void FetchFirstSelectable()
    {
        _selectedItem = Selectable.allSelectablesArray[0];
    }

    private void ResetSelection()
    {
        if (_selectedItem)
        {
            SetSelectableState(_selectedItem, false);
            _selectedItem = null;
        }
    }

    private void ManageSelection(Vector2 movementInput)
    {
        if (!_selectedItem)
        {
            FetchFirstSelectable();
        }

        SetSelectableState(_selectedItem, false);
        _selectedItem = HandleNavigation.ReturnSelectable(_selectedItem, movementInput);
        SetSelectableState(_selectedItem, true);
    }

    private void SetSelectableState(Selectable target, bool newState)
    {
        SelectedStateMarker marker = target.GetComponent<SelectedStateMarker>();
        marker.SetMarkedItem(newState);
    }

    private void ConfirmSelection()
    {
        if (!_selectedItem)
        {
            return;
        }

        RWUF_Button actionButton = _selectedItem.GetComponent<RWUF_Button>();
        actionButton.onClick?.Invoke();
    }
}
