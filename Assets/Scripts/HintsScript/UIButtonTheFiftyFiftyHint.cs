using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonTheFiftyFiftyHint : MonoBehaviour
{
    private Button theFiftyFiftyHintButton;

    private TimerRing timerRing;

    private bool activatedTheFiftyFiftyHint = false;
    public bool ActivatedTheFiftyFiftyHint { get => activatedTheFiftyFiftyHint; }

    private void Start()
    {
        theFiftyFiftyHintButton = GetComponent<Button>();
        timerRing = transform.parent.parent.GetComponent<TimerRing>();
        InteractableTheFiftyFiftyHint();
    }

    private void Update()
    {
        UsingTheFiftyFiftyHintIsAvailable();
    }

    public void UsingTheFiftyFiftyHint()
    {
        if (timerRing.IsTimer == true)
        {
            Debug.Log("UsingTheFiftyFiftyHint");
            TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint -= 1;
            activatedTheFiftyFiftyHint = true;
        }
    }

    private void UsingTheFiftyFiftyHintIsAvailable()
    {
        if (TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint <= 0)
        {
            theFiftyFiftyHintButton.enabled = false;
            theFiftyFiftyHintButton.GetComponent<Image>().color = Color.gray;
        }
        else if (activatedTheFiftyFiftyHint)
        {
            theFiftyFiftyHintButton.enabled = false;
        }
    }

    private void InteractableTheFiftyFiftyHint()
    {
        if (TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint > 0)
        {
            theFiftyFiftyHintButton.enabled = true;
        }
        else
        {
            theFiftyFiftyHintButton.enabled = false;
            theFiftyFiftyHintButton.GetComponent<Image>().color = Color.gray;
        }
    }
}
