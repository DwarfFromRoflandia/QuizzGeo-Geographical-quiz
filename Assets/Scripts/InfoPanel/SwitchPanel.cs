using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanel : MonoBehaviour
{
    [SerializeField] private GameObject _OrangePanel;
    [SerializeField] private GameObject _BluePanel;
    [SerializeField] private GameObject _CreamPanel;

    [SerializeField] private TimerHearts _timerHearts;

    private bool isOpenCreamPanel;
    public bool IsOpenCreamPanel { get { return isOpenCreamPanel; } set { isOpenCreamPanel = value; } }

    public void TurnOnOrangePanel()
    {
        _OrangePanel.SetActive(true);
        _BluePanel.SetActive(false);
        _CreamPanel.SetActive(false);
    }

    public void TurnOnBluePanel()
    {
        _OrangePanel.SetActive(false);
        _BluePanel.SetActive(true);
        _CreamPanel.SetActive(false);
    }

    public void TurnOnCreamPanel()
    {
        _OrangePanel.SetActive(false);
        _BluePanel.SetActive(false);
        _CreamPanel.SetActive(true);
        IsCreamPanel();
    }

    private void IsCreamPanel()
    {
        if (_timerHearts.IsTimer == true)
            isOpenCreamPanel = true;
        else
            isOpenCreamPanel = false;
    }
}
