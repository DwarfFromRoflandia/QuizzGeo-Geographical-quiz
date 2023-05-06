using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLevel : MonoBehaviour
{
    [SerializeField] private HeartsVersionTwo hearts;
    [SerializeField] private SaveAndLoadData saveAndLoadData;
    [SerializeField] private Animator animator;


    public void LoadTo(int level)//на этот метод мы будем ссылаться из редактора юнити для того, чтобы загрузить следующий уровень в игре
    {
        hearts.QuantityHearts--;

        StartCoroutine(TransitionAnumationCoroutine(level));
 
        Debug.Log("LoadTo");

        TransferStars.transferStras = 0;

        //saveAndLoadData._isLoadGameData = true;

        saveAndLoadData.Save();
    }



    private IEnumerator TransitionAnumationCoroutine(int level)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(level);
    }

}
