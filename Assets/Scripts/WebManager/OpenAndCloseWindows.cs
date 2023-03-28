using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class OpenAndCloseWindows : MonoBehaviour
{
    [SerializeField] private GameObject registrationWindow;
    [SerializeField] private GameObject loggingWindow;
    [SerializeField] private GameObject exitGameWindow;
    [SerializeField] private SaveDataForDataBase saveDataForDataBase;
    [SerializeField] private ErrorsHundler errorsHundler;

    private bool isRegistration = false;
    public bool IsRegistration { get { return isRegistration; } set { isRegistration = value; } }

    private bool isLogging = false;
    public bool IsLogging { get { return isLogging; } set { isLogging = value; } }

    private static bool isReloadingGameAfterLogining;


    /*
     * ƒобавить это свойство в SaveAndLoadData
     * —татика нужна дл€ того, чтобы не создавать Transfer переменную
     */
    public static bool IsReloadingGameAfterLogining { get { return isReloadingGameAfterLogining; } set { isReloadingGameAfterLogining = value; } }


    private void Start()
    {
        
    }
    private void Update()
    {
        if (!isRegistration && saveDataForDataBase.countGetDataFromDataBase == 0)
        {
            OpenRegWindow();
            //isRegistration = true;
        }

        if (!isLogging || errorsHundler.IsError)
        {
            OpenLogWindow();
            //Debug.Log("OpenLogWindow()");
        }
        if (isLogging && !errorsHundler.IsError)
        {
            CloseLogWindow();
        }

        //if (saveDataForDataBase.countGetDataFromDataBase <= 2 && !isReloadingGameAfterLogining)
        //{
        //    OpenExitGameWindow();
        //}

      
    }

    public void OpenRegWindow() => registrationWindow.SetActive(true);
   
    public void CloseRegWindow() => registrationWindow.SetActive(false);

    public void OpenLogWindow() => loggingWindow.SetActive(true);

    public void CloseLogWindow() => loggingWindow.SetActive(false);

    public void OpenExitGameWindow() => exitGameWindow.SetActive(true);

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }
}
