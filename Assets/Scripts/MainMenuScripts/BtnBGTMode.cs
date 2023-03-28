using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BtnBGTMode : MonoBehaviour
{
    [SerializeField] private GameObject levelSelected;
    [SerializeField] private TimerHearts timerHearts;
    [SerializeField] private Button playButton;
    [SerializeField] private SaveAndLoadData saveAndLoadData;

    
    private void Update()
    {
        DeactivateButton();
    }


    public void BGTModeHundler()
    {
        levelSelected.SetActive(true);
       Debug.Log("IndexLevel: " + TransferIndexLevel.transferIndexLevel);     
    }

    private void DeactivateButton()//метод, который блокирует кнопку при активации таймера восстановления сердец
    {
        if (timerHearts.IsTimer) playButton.enabled = false;
        else playButton.enabled = true;
    }
}
