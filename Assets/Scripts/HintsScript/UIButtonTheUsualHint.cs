using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonTheUsualHint : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private AnimationUsingUsualHint usingUsualHint;
    private TimerRing timerRing;

    private bool clampedButton;//булевская переменная, которая отвечает за то, зажата ли кнопка подсказки или нет
    public bool ClampedButton { get { return clampedButton; } set { clampedButton = value; } }

    private int clickButton = 0;//счётчик того, сколько раз игрок нажал на кнопку подсказки

    private Button theusualHint;

    private void Start()
    {
        usingUsualHint = transform.parent.parent.GetComponent<AnimationUsingUsualHint>();
        timerRing = transform.parent.parent.GetComponent<TimerRing>();
        theusualHint = GetComponent<Button>();
        clampedButton = false;
        InteractableTheUsualHint();       
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (TransferTheUsualHint.transferQuantityTheUsualHint > 0)
        {
            clampedButton = true;
            IncrementClickButton();
            UsingUsualHint();

            CanTheHintBeEnabled();
        }
        else if (TransferTheUsualHint.transferQuantityTheUsualHint == 0 && clickButton == 1)
        {
            clampedButton = true;

            CanTheHintBeEnabled();
        }
        
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        clampedButton = false;
        usingUsualHint.NoActivateUsualHint();
    }

    private void UsingUsualHint()
    {
        if (clampedButton == true && clickButton == 1 && timerRing.IsTimer == true && TransferTheUsualHint.transferQuantityTheUsualHint != 0)
            TransferTheUsualHint.transferQuantityTheUsualHint -= 1;
    }

    private void InteractableTheUsualHint()
    {
        if (TransferTheUsualHint.transferQuantityTheUsualHint > 0)
        {
            theusualHint.enabled = true;
            Debug.Log("Есть подсказки");
        }   
        else if (IsLastUsualHintUsed() && TransferTheUsualHint.transferQuantityTheUsualHint == 0)
        {
            theusualHint.enabled = true;
            Debug.Log("Есть подсказки");
            
            
        }   
        else
        {
            theusualHint.enabled = false;
            theusualHint.GetComponent<Image>().color = Color.gray;
            Debug.Log("Нет подсказок");
        }        
    }
                
    private void CanTheHintBeEnabled()
    {
        if (timerRing.IsTimer == true && clampedButton == true)
            usingUsualHint.ActivateUsualHint();
        else
            clampedButton = false;
    }
   private bool IsLastUsualHintUsed() => TransferTheUsualHint.transferQuantityTheUsualHint == 0 && clickButton == 1;

   private int IncrementClickButton() => clickButton++;
}
