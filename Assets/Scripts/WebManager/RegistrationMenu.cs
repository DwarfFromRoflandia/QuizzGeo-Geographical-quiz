using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegistrationMenu : MonoBehaviour
{


    [System.Serializable]
    public class MenuLogin
    {
        //public string nickname;
        //public string password;

        public Text nickname;
        public Text password;
    }

    [System.Serializable]
    public class MenuRegistration
    {
        //public string nickname;
        //public string password1;
        //public string password2;

        public Text nickname;
        public Text password1;
        public Text password2;
    }

    [SerializeField] private OpenAndCloseWindows openAndCloseWindows;
    private WebManager webManager;
    public MenuLogin menuLogin;
    public MenuRegistration menuRegistration;

    private bool isLoadingDataForDataBase;
    public bool IsLoadingDataForDataBase { get { return isLoadingDataForDataBase; } set { isLoadingDataForDataBase = value; } }

    public string nicknameInRegistration;
    public string passwordInRegistration;

    [SerializeField] private string nicknameInLogging;
    [SerializeField] private string passwordInLogging;

    //[SerializeField] private SaveAndLoadData saveAndLoadData;


    private void Start()
    {
        webManager = GetComponent<WebManager>();

        //nicknameInLogging = saveAndLoadData._nicknameInRegistration;
        //passwordInRegistration = saveAndLoadData._passwordInRegistration;
    }

    private void Update()
    {
        if (webManager.dataPlayer.playerData.ID != 0 && !isLoadingDataForDataBase)
        {
            if (EventManager.SaveDataForDataBaseEvent != null)
            {
                EventManager.SaveDataForDataBaseEvent.Invoke();
            }
            isLoadingDataForDataBase = true;
        }

        nicknameInRegistration = menuRegistration.nickname.text;
        passwordInRegistration = menuRegistration.password2.text;

        nicknameInLogging = menuLogin.nickname.text;
        passwordInLogging = menuLogin.password.text;
    }

   
    //первый способ входа в акк
    public void Login()
    {

        if (menuLogin.nickname.text == menuRegistration.nickname.text && menuLogin.password.text == menuRegistration.password2.text)
        {
            webManager.Login(menuLogin.nickname.text, menuLogin.password.text);

            if (EventManager.SaveDataForDataBaseEvent != null)
            {
                EventManager.SaveDataForDataBaseEvent.Invoke();
            }
            openAndCloseWindows.IsLogging = true;
        }

        
    }
    private IEnumerator LoggingCoroutine() //в эту корутину, пока выполняется вход в аккаутн, можно добавить метод с визуализацией загрузки, чтобы игрок видел, что идёт загрузка
    {
        Debug.Log("START");
        Login();
        yield return new WaitForSeconds(5);
        Login();
        Debug.Log("END");
    }

    //второй способ входа в акк
    public void ContinueLoginButton()
    {
        StartCoroutine(LoggingCoroutine());
    }

    public void Register()
    {
        

        if (menuRegistration.password1.text == menuRegistration.password2.text)
        {
            webManager.Registration(menuRegistration.nickname.text, menuRegistration.password1.text, menuRegistration.password2.text);
            openAndCloseWindows.CloseRegWindow();
            openAndCloseWindows.IsRegistration = true;
            //openAndCloseWindows.OpenLogWindow();
        }
        else
        {
            Debug.Log($"Uncorract password. Password 1: {menuRegistration.password1.text} != Password 2: {menuRegistration.password2.text}");
        }
    }
}
