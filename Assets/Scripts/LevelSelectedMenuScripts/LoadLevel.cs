using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLevel : MonoBehaviour
{
    [SerializeField] private HeartsVersionTwo hearts;
    [SerializeField] private SaveAndLoadData saveAndLoadData;


    public void LoadTo(int level)//�� ���� ����� �� ����� ��������� �� ��������� ����� ��� ����, ����� ��������� ��������� ������� � ����
    {
        hearts.QuantityHearts--;
     
        SceneManager.LoadScene(level);
 
        Debug.Log("LoadTo");

        TransferStars.transferStras = 0;

        //saveAndLoadData._isLoadGameData = true;

        saveAndLoadData.Save();
    }





}
