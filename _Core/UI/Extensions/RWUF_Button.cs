using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RWUF_Button : Button, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent OnPointerEnterEvent = new UnityEvent();
    public UnityEvent OnPointerExitEvent = new UnityEvent();

    public override void OnPointerEnter(PointerEventData eventData)
    {
        OnPointerEnterEvent?.Invoke();
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        OnPointerExitEvent?.Invoke();
    }
}
