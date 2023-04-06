using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContinueButtonInLog : SwitchWindow, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        ContinueActivateButtonAfterLog();
    }
}
