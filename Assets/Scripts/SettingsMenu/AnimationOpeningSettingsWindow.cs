using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOpeningSettingsWindow : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject SettingsPanel;

    private float timeUntilPanelCloses = 0.3f;





    public void OpenSettingsPanel()
    {
        settingsMenu.SetActive(true);
        _animator.SetTrigger("OpenInfoPanel");

    }

    public void ExitSettingsPanel()
    {
        StartCoroutine(ExitSettingsPanelCoroutine());
        _animator.SetTrigger("CloseInfoPanel");
    }

    IEnumerator ExitSettingsPanelCoroutine()
    {

        _animator.SetTrigger("CloseInfoPanel");
        yield return new WaitForSeconds(timeUntilPanelCloses);

        settingsMenu.SetActive(false);

        SettingsPanel.SetActive(true);

    }

   
}
