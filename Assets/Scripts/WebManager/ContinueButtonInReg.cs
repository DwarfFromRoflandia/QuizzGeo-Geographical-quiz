using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContinueButtonInReg : SwitchWindow, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        ContinueActivateButtonAfterReg();
    }
}
