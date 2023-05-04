using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]//данна€ строчка означает, что класс ниже мы сможем сохранить в файле
public class Data
{
    //полезные ссылки дл€ изучени€ конструктора класса https://www.youtube.com/watch?v=3edD7Z2wmsw и https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/classes-and-structs/constructors
    //данный скрипт будет представл€ть из себ€ просто объект в котором будут хранитьс€ наши данные, которые мы захотим сохранить.
    public int diamonds;
    public int quantityTheUsualHint;
    public int quantityTheFiftyFiftyHint;
    
    public int quantityHearts;
    public float timerHearts;
    public bool isTimer;
    public bool isFullHearts;
    public bool isTwoHearts;
    public bool isOneHearts;
    public bool noHearts;

    public int levelIndex;
    public int transferSrarsInBank;

    public int starsForFirstLevelInBank;
    public int starsForSecondLevelInBank;
    public int starsForThirdLevelInBank;
    public int starsForFourthLevelInBank;
    public int starsForFifthLevelInBank;

    public int achievedLevel;
    public int levelToUnlock;

    public bool isOpenInfoPanel;
    public bool isOpenCreamPanel;

    public bool isLoadGameData;

    public int ID;
    public string Nickname;
    public string Password;
    public int Score;
    public int CountGetDataFromDataBase;

    public bool isLoadingDataForDataBase;
    public bool isRegistration;

    public string nicknameInRegistration;
    public string passwordInRegistration;

    public int countScorePlayer;

    //public List<GameObject> PullPrefabLevelForSimpleLevel = new List<GameObject>();
    //public List<GameObject> PullPrefabLevelForLimitedTimeLevel = new List<GameObject>();
    //public List<GameObject> PullPrefabLevelForForHardLevel = new List<GameObject>();

    //public bool isActivateAssignment;


    //ниже мы создаЄм конструктор дл€ нашего класса
    public Data (SaveAndLoadData saveAndLoadData) 
    {
        diamonds = saveAndLoadData._diamonds;//берЄм значение переменной алмазов из скрипта saveAndLoadData и присваиваем это значеение в локальную переменную
        quantityTheUsualHint = saveAndLoadData._quantityTheUsualHint;
        quantityTheFiftyFiftyHint = saveAndLoadData._quantityTheFiftyFiftyHint;
        quantityHearts = saveAndLoadData._quantityHearts;
        
        timerHearts = saveAndLoadData._timerHearts;
        isTimer = saveAndLoadData._isTimer;
        isFullHearts = saveAndLoadData._isFullHearts;
        isTwoHearts = saveAndLoadData._isTwoHearts;
        isOneHearts = saveAndLoadData._isOneHearts;
        noHearts = saveAndLoadData._noHearts;   

        levelIndex = saveAndLoadData._levelIndex;
        transferSrarsInBank = saveAndLoadData._transferSrarsInBank;

        starsForFirstLevelInBank = saveAndLoadData._starsForFirstLevelInBank;
        starsForSecondLevelInBank = saveAndLoadData._starsForSecondLevelInBank;
        starsForThirdLevelInBank = saveAndLoadData._starsForThirdLevelInBank;
        starsForFourthLevelInBank = saveAndLoadData._starsForFourthLevelInBank;
        starsForFifthLevelInBank = saveAndLoadData._starsForFifthLevelInBank;

        achievedLevel = saveAndLoadData._achievedLevel;
        levelToUnlock = saveAndLoadData._levelToUnlock;

        isOpenInfoPanel = saveAndLoadData._isOpenInfoPanel;
        isOpenCreamPanel = saveAndLoadData._isOpenCreamPanel;

        isLoadGameData = saveAndLoadData._isLoadGameData;

        countScorePlayer = saveAndLoadData._countScorePlayer;

        //PullPrefabLevelForSimpleLevel = saveAndLoadData._PullPrefabLevelForSimpleLevel;
        //PullPrefabLevelForLimitedTimeLevel = saveAndLoadData._PullPrefabLevelForLimitedTimeLevel;
        //PullPrefabLevelForForHardLevel = saveAndLoadData._PullPrefabLevelForForHardLevel;
        //isActivateAssignment = saveAndLoadData._isActivateAssignment;
    }
}
