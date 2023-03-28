using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignsAttention : MonoBehaviour
{
    [SerializeField] private GameObject FirstSignAttention;
    [SerializeField] private GameObject SecondSignAttention;

    [SerializeField] private Animator FirstFigureAnim;
    [SerializeField] private Animator FirstQuestionMarkAnim;

    [SerializeField] private Animator SecondFigureAnim;
    [SerializeField] private Animator SecondQuestionMarkAnim;

    [SerializeField] private TimerHearts _timerHearts;

    [SerializeField] private SwitchPanel switchPanel;
    [SerializeField] private OpenAndExitInfoPanel openAndExitInfoPanel;


    private void Update()
    {
        IsFirstSignOn();
        IsSecondSignOn();
        IsFirstSignOff();
        IsSecondSignOff();
    }

    private void IsFirstSignOn()
    {
        if (_timerHearts.IsTimer && TransferIndexLevel.transferIndexLevel == 3)
        {
            FirstSignAttention.SetActive(true);

            FirstFigureAnim.SetTrigger("OnAnimFirstFigure");
            FirstQuestionMarkAnim.SetTrigger("OnAnimFirstQuestionMark");
        }
    }

    private void IsFirstSignOff()
    {
        if (!_timerHearts.IsTimer)
            FirstSignAttention.SetActive(false);
        else if (openAndExitInfoPanel.IsOpenInfoPanel == true)
            FirstSignAttention.SetActive(false);
    }

    private void IsSecondSignOff()
    {
        if (!_timerHearts.IsTimer)
            SecondSignAttention.SetActive(false);
        else if (switchPanel.IsOpenCreamPanel == true)
            SecondSignAttention.SetActive(false);
    }


    private void IsSecondSignOn()
    {
        if (_timerHearts.IsTimer && openAndExitInfoPanel.IsOpenInfoPanel == true && TransferIndexLevel.transferIndexLevel == 3)
        {
            SecondSignAttention.SetActive(true);
            SecondFigureAnim.SetTrigger("OnAnimSecondFigure");
            SecondQuestionMarkAnim.SetTrigger("OnAnimSecondQuestionMark");
        }
    }
}
