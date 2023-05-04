using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class SaveAndLoadData : MonoBehaviour
{
    [Header("—сылки дл€ тех переменных в которые будут присваиватьс€ значени€ дл€ сохранени€")]
    [SerializeField] private Products products;
    [SerializeField] private CountGem countGem;
    [SerializeField] private BGTStars bgtStars;
    [SerializeField] private LockLevel lockLevel;
    [SerializeField] private OpenAndExitInfoPanel openAndExitInfoPanel;
    [SerializeField] private SwitchPanel switchPanel;



    [Header("«начени€ переменных дл€ сохранени€ жизней")]
    private HeartsVersionTwo heartsVersionTwo;
    private TimerHearts timerHealth;

    [Header("«начени€ переменных дл€ сохранени€ алмазов")]
    public int _diamonds;
    public int _quantityTheUsualHint;
    public int _quantityTheFiftyFiftyHint;

    [Header("«начени€ переменных дл€ сохранени€ жизней")]
    public int _quantityHearts;
    public float _timerHearts;
    public bool _isTimer;
    public bool _isFullHearts;
    public bool _isTwoHearts;
    public bool _isOneHearts;
    public bool _noHearts;

    [Header("«начени€ переменных дл€ сохранени€ звЄзд")]
    public int _levelIndex;
    public int _transferSrarsInBank;

    public int _starsForFirstLevelInBank;
    public int _starsForSecondLevelInBank;
    public int _starsForThirdLevelInBank;
    public int _starsForFourthLevelInBank;
    public int _starsForFifthLevelInBank;

    [Header("«начени€ переменных дл€ сохранени€ уровней")]
    public int _achievedLevel;
    public int _levelToUnlock;


    [Header("«начени€ переменных дл€ сохранени€ активации знака внимани€")]
    public bool _isOpenInfoPanel;
    public bool _isOpenCreamPanel;

    private int countLoadGame;//счЄтчик, благодар€ которому загрузку данных мы будем производить только один раз за одну игровую сессию

    public bool _isLoadGameData;//переменна€, котора€ отвечает за то, чтобы загрузка данных не срабатывала, когда игрок только впервые заходит в игру, во избежани€ багов

    [Header("«начени€ переменных дл€ ,базы данных")]
    public int _countScorePlayer;

    //[Header("«начени€ переменных дл€ сохранени€ массивов с префабами уровней")]
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


        _countScorePlayer = CounterScoreForDataBase.countScorePlayer;

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

            _countScorePlayer = data.countScorePlayer;

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

            CounterScoreForDataBase.countScorePlayer = data.countScorePlayer;
            //PullPrefabLevelArray.instance.PullPrefabLevelForSimpleLevel = data.PullPrefabLevelForSimpleLevel;
            //prefabLevelArray.PrefabLevelArrayForLimitedTimeLevel = data.PullPrefabLevelForLimitedTimeLevel;
            //prefabLevelArray.PrefabLevelArrayForHardLevel = data.PullPrefabLevelForForHardLevel;

             //PrefabLevelArray.isActivateAssignment = data.isActivateAssignment;


            Debug.Log("ѕеременна€ _diamonds равна значению: " + _diamonds);

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


    //        Debug.Log("ѕеременна€ _diamonds равна значению: " + _diamonds);

    //        Debug.Log("countLoadGame = " + countLoadGame);

    //    }

    //}

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pause) //метод, который овечает за то, когда приложение сворачиваетс€ на андройде
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
