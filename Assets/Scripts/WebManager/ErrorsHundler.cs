using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorsHundler : MonoBehaviour
{
    [SerializeField] private OpenAndCloseWindows openAndCloseWindows;
    //[SerializeField] private SaveAndLoadData saveAndLoadData;
    
    private SaveDataForDataBase saveDataForDataBase;
    private WebManager webManager;
    public string Error;

    private bool isError;

    public bool IsError { get => isError; }

    private void Start()
    {
        webManager = GetComponent<WebManager>();
        saveDataForDataBase = GetComponent<SaveDataForDataBase>();
    }


    private void Update()
    {
        Test();
    }

    private void Test()
    {
        if (saveDataForDataBase.ID != webManager.dataPlayer.playerData.ID)
        {
            isError = true;
        }
        else
        {
            isError = false;
        }
    }
}
