using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndExitInfoPanel : MonoBehaviour
{
   [SerializeField] private GameObject _infoPanel;

   [SerializeField] private GameObject _OrangePanel;
   [SerializeField] private GameObject _BluePanel;
   [SerializeField] private GameObject _CreamPanel;

   [SerializeField] private Animator _animator;

   [SerializeField] private TimerHearts _timerHearts;

    private float timeUntilPanelCloses = 0.3f;
    private bool needClosePanel = false;

    private bool isOpenInfoPanel;
    public bool IsOpenInfoPanel { get { return isOpenInfoPanel; } set { isOpenInfoPanel = value; } }

    public void OpenInfoPanel()
    {
        _infoPanel.SetActive(true);
        _animator.SetTrigger("OpenInfoPanel");
        IsInfoPanel();
    }

    public void ExitInfoPanel()
    {
        StartCoroutine(CloseInfoPanel());
        _animator.SetTrigger("CloseInfoPanel");
    }

    IEnumerator CloseInfoPanel()
    {
        needClosePanel = true;
        _animator.SetTrigger("CloseInfoPanel");
        yield return new WaitForSeconds(timeUntilPanelCloses);
        needClosePanel = false;
        
        _infoPanel.SetActive(false);

        _OrangePanel.SetActive(true);
        _BluePanel.SetActive(false);
        _CreamPanel.SetActive(false);
    }

    private void IsInfoPanel()
    {
        if (_timerHearts.IsTimer == true)
            isOpenInfoPanel = true;
        else
            isOpenInfoPanel = false;
    }
}
