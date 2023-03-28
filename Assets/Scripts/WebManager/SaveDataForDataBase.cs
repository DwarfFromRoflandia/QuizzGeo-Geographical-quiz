using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SaveDataForDataBase : MonoBehaviour
{
    [SerializeField] private Text textPassword;
    [SerializeField] private PlayerBuilder playerBuilder;
    private DataLoader dataLoader;
    private RegistrationMenu registrationMenu;
    private WebManager webManager;

    /*
     * Сначала я решистрирую новго пользователя. Потом вхожу в аккаунт.
     * Выключаю игру и снова включаю. В этом скрипте в поле Nickname
     * появляется spider_01 вместо spider_049. Из-за этого ломается логика игры, а также ломаются данные в WebManager.
     * Исправить этот баг
     */

    public int ID;
    public string Nickname;
    public int Score;
    public string Password;

    private bool isLoadDataFromSaveSystem = false;

    private int dontChangeValueScore;

    private bool isChangeScoreInDataBase;
    public bool IsChangeScoreInDataBase { get { return isChangeScoreInDataBase; } set { isChangeScoreInDataBase = value; } }

    public int countGetDataFromDataBase;

    private void Start()
    {
        

        EventManager.SaveDataForDataBaseEvent.AddListener(GetDataLoading);
        EventManager.ChangeQuantityScoreEvent.AddListener(CounterScore);
        registrationMenu = GetComponent<RegistrationMenu>();
        webManager = GetComponent<WebManager>();
        dataLoader = GetComponent<DataLoader>();

        //Debug.Log("TransferValuesForDataBase._Score: " + TransferValuesForDataBase._Score);

        

    }
    private void Update()
    {
        //Score = WebManager.dataPlayer.playerData.score;
        playerBuilder.Score = Score;
        //ChangedValue();

        //Score = TransferValuesForDataBase._Score;

        ChangeScoreInDataBase();       
    }

    private void FixedUpdate()
    {
        if (ID != 0 && !isLoadDataFromSaveSystem)
        {
            SetDataLoading();
            isLoadDataFromSaveSystem = true;
            Debug.Log("SetDataLoading()");
        }
    }


    private void ChangeScoreInDataBase()
    {
        if (Score != dontChangeValueScore)
        {
            isChangeScoreInDataBase = true;
            dontChangeValueScore = Score;
            Debug.Log("SCORE CHANGED");
        }
        else
        {
            isChangeScoreInDataBase = false;
        }
    }

    public void CounterScore(int quantityRightAnswer)
    {
        // TransferValuesForDataBase._Score = TransferValuesForDataBase._Score + quantityRightAnswer;

        //Debug.Log("TransferValuesForDataBase._Score: " + TransferValuesForDataBase._Score);

        Score = Score + quantityRightAnswer;
    }

    public void GetDataLoading()//метод для кнопки Continue в окне Logging
    {
        ID = webManager.dataPlayer.playerData.ID;
        Nickname = webManager.dataPlayer.playerData.nickname;
        Score = webManager.dataPlayer.playerData.score;
        Password = textPassword.text;

        countGetDataFromDataBase++;

        Debug.Log("Loading");
    }

    public void SetDataLoading()
    {
        webManager.dataPlayer.playerData.ID = ID;
        //registrationMenu.menuLogin.nickname.text = Nickname;
        webManager.dataPlayer.playerData.nickname = Nickname;
        registrationMenu.menuLogin.password.text = Password;
        webManager.dataPlayer.playerData.score = Score;
        webManager.Login(registrationMenu.menuLogin.nickname.text, registrationMenu.menuLogin.password.text);
    }

    //public void TestButton()
    //{
    //    Debug.Log("ID: " + WebManager.dataPlayer.playerData.ID);
    //    Debug.Log("Nickname: " + WebManager.dataPlayer.playerData.nickname);
    //    Debug.Log("Score: " + WebManager.dataPlayer.playerData.score);
    //}

    private void OnEnable()
    {
        if (TransferValuesForDataBase._ID != 0 && TransferValuesForDataBase._Nickname != null)
        {
            ID = TransferValuesForDataBase._ID;
            Nickname = TransferValuesForDataBase._Nickname;
            Password = TransferValuesForDataBase._Password;
            Score = TransferValuesForDataBase._Score;
            countGetDataFromDataBase = TransferValuesForDataBase._CountGetDataFromDataBase;
        }
    }

    private void OnDestroy()
    {
        TransferValuesForDataBase._ID = ID;
        TransferValuesForDataBase._Nickname = Nickname;
        TransferValuesForDataBase._Password = Password;
        TransferValuesForDataBase._Score = Score;
        TransferValuesForDataBase._CountGetDataFromDataBase = countGetDataFromDataBase;
    }
}
