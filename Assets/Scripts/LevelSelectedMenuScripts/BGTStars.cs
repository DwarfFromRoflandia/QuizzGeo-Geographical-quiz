using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGTStars : MonoBehaviour
{
    [Header("¬ключЄнные звЄзды")]

    public GameObject[] StarsOn; //создаЄм массив включЄнных звЄзд

    //булевские переменные, которые провер€ют в условии к какому уровню подключать звЄзды
    private bool lvl1 = false;
    public bool Lvl1 { get { return lvl1; } set { lvl1 = value; } }


    private bool lvl2 = false;
    public bool Lvl2 { get { return lvl2; } set { lvl2 = value; } }


    private bool lvl3 = false;
    public bool Lvl3 { get { return lvl3; } set { lvl3 = value; } }


    private bool lvl4 = false;
    public bool Lvl4 { get { return lvl4; } set { lvl4 = value; } }


    private bool lvl5 = false;
    public bool Lvl5 { get { return lvl5; } set { lvl5 = value; } }

    private void Start()
    {
        Stars();
        LevelCompleted1();
        LevelCompleted2();
        LevelCompleted3();
        LevelCompleted4();
        LevelCompleted5();

        Debug.Log("Get active scine in menu selected levels: " + TransferIndexLevel.transferIndexLevel);
       
    }

    //ниже представлены п€ть методов, которые провер€ют через индекс уровн€ к которому нужно добавл€ть звЄзды
    private void LevelCompleted1()
    {
        if (TransferIndexLevel.transferIndexLevel == 1)
        {
            if (lvl1)
            {
                
                GettingStarsToTheFirstLevel();
            }
            else
            {
                lvl1 = false;
            }
        }
        
    }

    private void LevelCompleted2()
    {
        if (TransferIndexLevel.transferIndexLevel == 2)
        {
            if (lvl2)
            {
                
                GettingStarsToTheSecondLevel();
                GettingStarsToTheFirstLevel();
            }

            else
            {
                lvl2 = false;
            }
        }             
    }

    private void LevelCompleted3()
    {
        if (TransferIndexLevel.transferIndexLevel == 3)
        {
            if (lvl3)
            {
                GettingStarsToTheThierdLevel();
                GettingStarsToTheFirstLevel();
                GettingStarsToTheSecondLevel();               
            }
            else
            {
                lvl3 = false;
            }
        }
    }

    private void LevelCompleted4()
    {
        if (TransferIndexLevel.transferIndexLevel == 4)
        {
            if (lvl4)
            {
                GettingStarsToTheFourthLevel();
                GettingStarsToTheFirstLevel();
                GettingStarsToTheSecondLevel();
                GettingStarsToTheThierdLevel();

            }
            else
            {
                lvl4 = false;
            }
        }
    }

    private void LevelCompleted5()
    {
        if (TransferIndexLevel.transferIndexLevel == 5)
        {
            if (lvl5)
            {
                GettingStarsToTheFiveLevel();
                GettingStarsToTheFirstLevel();
                GettingStarsToTheSecondLevel();
                GettingStarsToTheThierdLevel();
                GettingStarsToTheFourthLevel();
            }
            else
            {
                lvl5 = false;
            }
        }
    }

    //ниже представленные 5 методов, которые при определЄнном условии добавл€ют от 1 до 3 звЄзд
    private void GettingStarsToTheFirstLevel()
    {
        Bank.instance.Stars();

        if (Bank.instance.levelSrarOne >= 3 && Bank.instance.levelSrarOne < 6)
        {
            StarsOn[0].SetActive(true);
        }
        if (Bank.instance.levelSrarOne >= 6 && Bank.instance.levelSrarOne < 9)
        {
            StarsOn[0].SetActive(true);
            StarsOn[1].SetActive(true);
        }
        if (Bank.instance.levelSrarOne >= 9)
        {
            StarsOn[0].SetActive(true);
            StarsOn[1].SetActive(true);
            StarsOn[2].SetActive(true);
        }
    }

    private void GettingStarsToTheSecondLevel()
    {
        Bank.instance.Stars();

        if (Bank.instance.levelSrarTwo >= 3 && Bank.instance.levelSrarTwo < 6)
        {
            StarsOn[3].SetActive(true);
        }
        if (Bank.instance.levelSrarTwo >= 6 && Bank.instance.levelSrarTwo < 9)
        {
            StarsOn[3].SetActive(true);
            StarsOn[4].SetActive(true);
        }
        if (Bank.instance.levelSrarTwo >= 9)
        {
            StarsOn[3].SetActive(true);
            StarsOn[4].SetActive(true);
            StarsOn[5].SetActive(true);
        }
    }

    private void GettingStarsToTheThierdLevel()
    {
        Bank.instance.Stars();

        if (Bank.instance.levelSrarThree >= 3 && Bank.instance.levelSrarThree < 6)
        {
            StarsOn[6].SetActive(true);
        }

        if (Bank.instance.levelSrarThree >= 6 && Bank.instance.levelSrarThree < 9)
        {
            StarsOn[6].SetActive(true);
            StarsOn[7].SetActive(true);
        }

        if (Bank.instance.levelSrarThree >= 9)
        {
            StarsOn[6].SetActive(true);
            StarsOn[7].SetActive(true);
            StarsOn[8].SetActive(true);
        }
    }



    private void GettingStarsToTheFourthLevel()
    {
        Bank.instance.Stars();

        if (Bank.instance.levelSrarFour >= 3 && Bank.instance.levelSrarFour < 6)
        {
            StarsOn[9].SetActive(true);
        }
        if (Bank.instance.levelSrarFour >= 6 && Bank.instance.levelSrarFour < 9)
        {
            StarsOn[9].SetActive(true);
            StarsOn[10].SetActive(true);
        }
        if (Bank.instance.levelSrarFour >= 9)
        {
            StarsOn[9].SetActive(true);
            StarsOn[10].SetActive(true);
            StarsOn[11].SetActive(true);
        }
    }

    private void GettingStarsToTheFiveLevel()
    {
        Bank.instance.Stars();

        if (Bank.instance.levelSrarFive >= 3 && Bank.instance.levelSrarFive < 6)
        {
            StarsOn[12].SetActive(true);
        }
        if (Bank.instance.levelSrarFive >= 6 && Bank.instance.levelSrarFive < 9)
        {
            StarsOn[12].SetActive(true);
            StarsOn[13].SetActive(true);
        }
        if (Bank.instance.levelSrarFive >= 9)
        {
            StarsOn[12].SetActive(true);
            StarsOn[13].SetActive(true);
            StarsOn[14].SetActive(true);
        }
    }

    //преключатель, который переключает булеввские переменные при определЄнном условии
    private void Stars()
    {
        switch (TransferIndexLevel.transferIndexLevel)
        {
            case 1:
                lvl1 = true;    
                break;

            case 2:
                lvl2 = true;
                break;
           
            case 3:
                lvl3 = true;
                break;

            case 4:
                lvl4 = true;
                break;

            case 5:
                lvl5 = true;
                break;
        }
    }

}

