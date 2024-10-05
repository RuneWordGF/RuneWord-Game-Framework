using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;

public class InputBridge : MonoBehaviour
{
    private BasicControls _controlMap;

    public UnityEvent OnSchemeChanged = new UnityEvent();

    public UnityEvent<Vector2> OnMoving = new UnityEvent<Vector2>();
    public UnityEvent OnConfirm = new UnityEvent();

    public UnityEvent<Vector2> OnLooking = new UnityEvent<Vector2>();

    private void Start()
    {
        _controlMap = new BasicControls();
        _controlMap.Enable();

        InputUser.onChange += (args0, args1, device) => SchemeChanged(device);

        _controlMap.Player.Move.started    += (args) => Moving(args);
        _controlMap.Player.Confirm.started += (args) => ConfirmAction(args);
        _controlMap.Player.Look.started    += (args) => Looking(args);
    }

    private void SchemeChanged(InputDevice newDevice)
    {
        OnSchemeChanged?.Invoke();
    }

    private void Moving(InputAction.CallbackContext args)
    {
        Vector2 movementResult = args.ReadValue<Vector2>();

        OnMoving?.Invoke(movementResult);
    }

    private void ConfirmAction(InputAction.CallbackContext args)
    {
        OnConfirm?.Invoke();
    }

    private void Looking(InputAction.CallbackContext args)
    {
        Vector2 movementResult = args.ReadValue<Vector2>();

        OnLooking?.Invoke(movementResult);
    }
}
