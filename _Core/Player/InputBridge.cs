using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputBridge : MonoBehaviour
{
    public PlayerInput Controller;
    private BasicControls ControlMap;

    public Selectable SelectedItem;

    private void Start()
    {
        ControlMap = new BasicControls();

        Controller.enabled = true;
        ControlMap.Enable();
        ControlMap.Player.Fire.started += (args) => PrintCheck();
        ControlMap.Player.Move.started += (args) => PrintMove(args);
        ControlMap.Player.Look.started += (args) => What(args);
    }

    private void PrintCheck()
    {
        // Debug.Log("Fire was shot");
    }

    private void PrintMove(InputAction.CallbackContext args)
    {
        Vector2 movementResult = args.ReadValue<Vector2>();
        bool moveVer = movementResult.y != 0;
        bool moveHor = movementResult.x != 0;
        bool moveUp = movementResult.y > 0;
        bool moveRight = movementResult.x > 0;

        SetSelectableState(SelectedItem, false);
        SelectedItem = HandleNavigation.ReturnSelectable(SelectedItem, movementResult);
        SetSelectableState(SelectedItem, true);

        // Debug.Log(movementResult.x);
        // Debug.Log(movementResult.y);
    }

    private void SetSelectableState(Selectable target, bool newState)
    {
        SelectedStateMarker marker = target.GetComponent<SelectedStateMarker>();
        marker.SetMarkedItem(newState);
    } 

    private void What(InputAction.CallbackContext args)
    {
        Vector2 movementResult = args.ReadValue<Vector2>();
        // Debug.Log(movementResult.x + " | " + movementResult.y);
        // Debug.Log(movementResult.y);
    }
}
