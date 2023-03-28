using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class SaveAndLoadData : MonoBehaviour
{
    [Header("Ссылки для тех переменных в которые будут присваиваться значения для сохранения")]
    [SerializeField] private Products products;
    [SerializeField] private CountGem countGem;
    [SerializeField] private BGTStars bgtStars;
    [SerializeField] private LockLevel lockLevel;
    [SerializeField] private OpenAndExitInfoPanel openAndExitInfoPanel;
    [SerializeField] private SwitchPanel switchPanel;
    [SerializeField] private SaveDataForDataBase saveDataForDataBase;
    [SerializeField] private RegistrationMenu registrationMenu;
    [SerializeField] private OpenAndCloseWindows openAndCloseWindows;

    [Header("Значения переменных для сохранения жизней")]
    private HeartsVersionTwo heartsVersionTwo;
    private TimerHearts timerHealth;

    [Header("Значения переменных для сохранения алмазов")]
    public int _diamonds;
    public int _quantityTheUsualHint;
    public int _quantityTheFiftyFiftyHint;

    [Header("Значения переменных для сохранения жизней")]
    public int _quantityHearts;
    public float _timerHearts;
    public bool _isTimer;
    public bool _isFullHearts;
    public bool _isTwoHearts;
    public bool _isOneHearts;
    public bool _noHearts;

    [Header("Значения переменных для сохранения звёзд")]
    public int _levelIndex;
    public int _transferSrarsInBank;

    public int _starsForFirstLevelInBank;
    public int _starsForSecondLevelInBank;
    public int _starsForThirdLevelInBank;
    public int _starsForFourthLevelInBank;
    public int _starsForFifthLevelInBank;

    [Header("Значения переменных для сохранения уровней")]
    public int _achievedLevel;
    public int _levelToUnlock;


    [Header("Значения переменных для сохранения активации знака внимания")]
    public bool _isOpenInfoPanel;
    public bool _isOpenCreamPanel;

    private int countLoadGame;//счётчик, благодаря которому загрузку данных мы будем производить только один раз за одну игровую сессию

    public bool _isLoadGameData;//переменная, которая отвечает за то, чтобы загрузка данных не срабатывала, когда игрок только впервые заходит в игру, во избежания багов


    [Header("Значения переменных для сохранения регистрации и авторизации пользователя")]
    public int _ID;
    public string _Nickname;
    public string _Password;
    public int _Score;
    public int _CountGetDataFromDataBase;


    public bool _isLoadingDataForDataBase;
    public bool _isRegistration;

    public string _nicknameInRegistration;
    public string _passwordInRegistration;



    //[Header("Значения переменных для сохранения массивов с префабами уровней")]
    //public List<GameObject> _PullPrefabLevelForSimpleLevel = new List<GameObject>();
    //public List<GameObject> _PullPrefabLevelForLimitedTimeLevel = new List<GameObject>();
    //public List<GameObject> _PullPrefabLevelForForHardLevel = new List<GameObject>();

    //public bool _isActivateAssignment;

    private PrefabLevelArray prefabLevelArray;

    private void Start()
    {
        heartsVersionTwo = GetComponent<HeartsVersionTwo>();
        timerHealth = GetComponent<TimerHearts>();
        prefabLevelArray = GetComponent<PrefabLevelArray>();

        Load();
    }


    private void Update()
    {
      
        TransferCountLoadGameIndex.countIndextLoadGame = countLoadGame;

        _diamonds = countGem.QuantityGem;
        _quantityTheUsualHint = TransferTheUsualHint.transferQuantityTheUsualHint;
        _quantityTheFiftyFiftyHint = TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint;
        
        _quantityHearts = heartsVersionTwo.QuantityHearts;
        _timerHearts = timerHealth.ontime;
        _isTimer = timerHealth.IsTimer;
        _isFullHearts = heartsVersionTwo.IsFullHearts;
        _isTwoHearts = heartsVersionTwo.IsTwoHearts;
        _isOneHearts = heartsVersionTwo.IsOneHearts;
        _noHearts = heartsVersionTwo.NoHearts;
        

        _levelIndex = TransferIndexLevel.transferIndexLevel;
        _transferSrarsInBank = TransferStars.transferStras;

        _starsForFirstLevelInBank = Bank.instance.levelSrarOne;
        _starsForSecondLevelInBank = Bank.instance.levelSrarTwo;
        _starsForThirdLevelInBank = Bank.instance.levelSrarThree;
        _starsForFourthLevelInBank = Bank.instance.levelSrarFour;
        _starsForFifthLevelInBank = Bank.instance.levelSrarFive;

        _achievedLevel = lockLevel.LevelReached;
        _levelToUnlock = TransferValueLevelToUnlock.valueLevelToUnlock;

        _isOpenInfoPanel = openAndExitInfoPanel.IsOpenInfoPanel;
        _isOpenCreamPanel = switchPanel.IsOpenCreamPanel;


        if (_CountGetDataFromDataBase <= 2)
        {
            _ID = saveDataForDataBase.ID;
            _Nickname = saveDataForDataBase.Nickname;
            _Password = saveDataForDataBase.Password;


        }

        _nicknameInRegistration = registrationMenu.nicknameInRegistration;
        _passwordInRegistration = registrationMenu.passwordInRegistration;

        _Score = saveDataForDataBase.Score;
        _CountGetDataFromDataBase = saveDataForDataBase.countGetDataFromDataBase;

        _isLoadingDataForDataBase = registrationMenu.IsLoadingDataForDataBase;
        _isRegistration = openAndCloseWindows.IsRegistration;



        //_PullPrefabLevelForSimpleLevel = PullPrefabLevelArray.instance.PullPrefabLevelForSimpleLevel;
        //_PullPrefabLevelForLimitedTimeLevel = prefabLevelArray.PrefabLevelArrayForLimitedTimeLevel;
        //_PullPrefabLevelForForHardLevel = prefabLevelArray.PrefabLevelArrayForHardLevel;

        //_isActivateAssignment = PrefabLevelArray.isActivateAssignment;


    }
    public void Save()
    {
        SaveSystem.SaveData(this);
        Debug.Log("TransferValueLevelToUnlock.valueLevelToUnlock " + _achievedLevel);
    }

    public void Load()
    {
        if (countLoadGame == 0)
        {
            Data data = SaveSystem.LoadData();

            _diamonds = data.diamonds;
            _quantityTheUsualHint = data.quantityTheUsualHint;
            _quantityTheFiftyFiftyHint = data.quantityTheFiftyFiftyHint;

            _quantityHearts = data.quantityHearts;
            _timerHearts = data.timerHearts;
            _isTimer = data.isTimer;
            _isFullHearts = data.isFullHearts;
            _isTwoHearts = data.isTwoHearts;
            _isOneHearts = data.isOneHearts;
            _noHearts = data.noHearts;

            _levelIndex = data.levelIndex;
            _transferSrarsInBank = data.transferSrarsInBank;

            _starsForFirstLevelInBank = data.starsForFirstLevelInBank;
            _starsForSecondLevelInBank = data.starsForSecondLevelInBank;
            _starsForThirdLevelInBank = data.starsForThirdLevelInBank;
            _starsForFourthLevelInBank = data.starsForFourthLevelInBank;
            _starsForFifthLevelInBank = data.starsForFifthLevelInBank;

            _achievedLevel = data.achievedLevel;
            _levelToUnlock = data.levelToUnlock;

            _isOpenInfoPanel = data.isOpenInfoPanel;
            _isOpenCreamPanel = data.isOpenCreamPanel;

            _ID = data.ID;
            _Nickname = data.Nickname;
            _Password = data.Password;

            _Score = data.Score;
            _CountGetDataFromDataBase = data.CountGetDataFromDataBase;

            _isLoadingDataForDataBase = data.isLoadingDataForDataBase;
            _isRegistration = data.isRegistration;

            _nicknameInRegistration = data.nicknameInRegistration;
            _passwordInRegistration = data.passwordInRegistration;

            //_PullPrefabLevelForSimpleLevel = data.PullPrefabLevelForSimpleLevel;
            //_PullPrefabLevelForLimitedTimeLevel = data.PullPrefabLevelForLimitedTimeLevel;
            //_PullPrefabLevelForForHardLevel = data.PullPrefabLevelForForHardLevel;
            //_isActivateAssignment = data.isActivateAssignment;


            //****************************************************************************************************************************************************


            countGem.QuantityGem = data.diamonds;
            TransferTheUsualHint.transferQuantityTheUsualHint = data.quantityTheUsualHint;
            TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint = data.quantityTheFiftyFiftyHint;

            heartsVersionTwo.QuantityHearts = data.quantityHearts;
            timerHealth.ontime = data.timerHearts;
            timerHealth.IsTimer = data.isTimer;
            heartsVersionTwo.IsFullHearts = data.isFullHearts;
            heartsVersionTwo.IsTwoHearts = data.isTwoHearts;
            heartsVersionTwo.IsOneHearts = data.isOneHearts;
            heartsVersionTwo.NoHearts = data.noHearts;

            TransferIndexLevel.transferIndexLevel = data.levelIndex;
            TransferStars.transferStras = data.transferSrarsInBank;

            Bank.instance.levelSrarOne = data.starsForFirstLevelInBank;
            Bank.instance.levelSrarTwo = data.starsForSecondLevelInBank;
            Bank.instance.levelSrarThree = data.starsForThirdLevelInBank;
            Bank.instance.levelSrarFour = data.starsForFourthLevelInBank;
            Bank.instance.levelSrarFive = data.starsForFifthLevelInBank;

            lockLevel.LevelReached = data.achievedLevel;
            TransferValueLevelToUnlock.valueLevelToUnlock = data.levelToUnlock;

            openAndExitInfoPanel.IsOpenInfoPanel = data.isOpenInfoPanel;
            switchPanel.IsOpenCreamPanel = data.isOpenCreamPanel;

            saveDataForDataBase.ID = data.ID;
            saveDataForDataBase.Nickname = data.Nickname;
            saveDataForDataBase.Password = data.Password;
            saveDataForDataBase.Score = data.Score;
            saveDataForDataBase.countGetDataFromDataBase = data.CountGetDataFromDataBase;

            registrationMenu.IsLoadingDataForDataBase = data.isLoadingDataForDataBase;
            openAndCloseWindows.IsRegistration = data.isRegistration;

            registrationMenu.nicknameInRegistration = data.nicknameInRegistration;
            registrationMenu.passwordInRegistration = data.passwordInRegistration;

            //PullPrefabLevelArray.instance.PullPrefabLevelForSimpleLevel = data.PullPrefabLevelForSimpleLevel;
            //prefabLevelArray.PrefabLevelArrayForLimitedTimeLevel = data.PullPrefabLevelForLimitedTimeLevel;
            //prefabLevelArray.PrefabLevelArrayForHardLevel = data.PullPrefabLevelForForHardLevel;

             //PrefabLevelArray.isActivateAssignment = data.isActivateAssignment;


            Debug.Log("Переменная _diamonds равна значению: " + _diamonds);

            Debug.Log("countLoadGame = " + countLoadGame);



            countLoadGame++;
        }
        
    }


    //public void Load()
    //{
    //    Data data = SaveSystem.LoadData();

    //    _isLoadGameData = data.isLoadGameData;
    //    countLoadGame++;

    //    if (countLoadGame > 0 && countLoadGame < 2 && _isLoadGameData == true)
    //    {      
    //        _diamonds = data.diamonds;
    //        _quantityTheUsualHint = data.quantityTheUsualHint;
    //        _quantityTheFiftyFiftyHint = data.quantityTheFiftyFiftyHint;

    //        _quantityHearts = data.quantityHearts;
    //        _timerHearts = data.timerHearts;
    //        _isTimer = data.isTimer;
    //        _isFullHearts = data.isFullHearts;
    //        _isTwoHearts = data.isTwoHearts;
    //        _isOneHearts = data.isOneHearts;
    //        _noHearts = data.noHearts;

    //        _levelIndex = data.levelIndex;
    //        _transferSrarsInBank = data.transferSrarsInBank;

    //        _starsForFirstLevelInBank = data.starsForFirstLevelInBank;
    //        _starsForSecondLevelInBank = data.starsForSecondLevelInBank;
    //        _starsForThirdLevelInBank = data.starsForThirdLevelInBank;
    //        _starsForFourthLevelInBank = data.starsForFourthLevelInBank;
    //        _starsForFifthLevelInBank = data.starsForFifthLevelInBank;

    //        _achievedLevel = data.achievedLevel;
    //        _levelToUnlock = data.levelToUnlock;

    //        _isOpenInfoPanel = data.isOpenInfoPanel;
    //        _isOpenCreamPanel = data.isOpenCreamPanel;



    //        countGem.QuantityGem = data.diamonds;
    //        TransferTheUsualHint.transferQuantityTheUsualHint = data.quantityTheUsualHint;
    //        TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint = data.quantityTheFiftyFiftyHint;

    //        heartsVersionTwo.QuantityHearts = data.quantityHearts;
    //        timerHealth.ontime = data.timerHearts;
    //        timerHealth.IsTimer = data.isTimer;
    //        heartsVersionTwo.IsFullHearts = data.isFullHearts;
    //        heartsVersionTwo.IsTwoHearts = data.isTwoHearts;
    //        heartsVersionTwo.IsOneHearts = data.isOneHearts;
    //        heartsVersionTwo.NoHearts = data.noHearts;

    //        TransferIndexLevel.transferIndexLevel = data.levelIndex;
    //        TransferStars.transferStras = data.transferSrarsInBank;

    //        Bank.instance.levelSrarOne = data.starsForFirstLevelInBank;
    //        Bank.instance.levelSrarTwo = data.starsForSecondLevelInBank;
    //        Bank.instance.levelSrarThree = data.starsForThirdLevelInBank;
    //        Bank.instance.levelSrarFour = data.starsForFourthLevelInBank;
    //        Bank.instance.levelSrarFive = data.starsForFifthLevelInBank;

    //        lockLevel.LevelReached = data.achievedLevel;
    //        TransferValueLevelToUnlock.valueLevelToUnlock = data.levelToUnlock;

    //        openAndExitInfoPanel.IsOpenInfoPanel = data.isOpenInfoPanel;
    //        switchPanel.IsOpenCreamPanel = data.isOpenCreamPanel;


    //        Debug.Log("Переменная _diamonds равна значению: " + _diamonds);

    //        Debug.Log("countLoadGame = " + countLoadGame);

    //    }

    //}

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pause) //метод, который овечает за то, когда приложение сворачивается на андройде
    {
        if (pause) Save();       
    }

    private void OnEnable()
    {
        if (TransferCountLoadGameIndex.countIndextLoadGame != 0) countLoadGame = TransferCountLoadGameIndex.countIndextLoadGame;
    }

    private void OnDestroy()
    {
        TransferCountLoadGameIndex.countIndextLoadGame = countLoadGame;
    }
}
