using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank 
{

    public int levelSrarOne;
    public int levelSrarTwo;
    public int levelSrarThree; 
    public int levelSrarFour;
    public int levelSrarFive;
    public static Bank instance 
    {
        get
        {
            if (_instance == null)//этим условием мы проверяем, если у нас переменная instance ещё не создана (т.е. она равна null), то мы создаём её, иначе пусть свойство возращает нам эту переменную
            {
                _instance = new Bank();
            }
            return _instance;  
        }
    }

    private static Bank _instance;

    public void PlusThreeGem()
    {
        TransferGem.transferGems += 3;
        
        Debug.Log("PlusThreeGem");
    }

    public void PlusSixGem()
    {
        TransferGem.transferGems += 6;
        
        Debug.Log("PlusSixGem");
    }

    public void PlusNineGem()
    {
        TransferGem.transferGems += 9;

        Debug.Log("PlusNineGem");
    }

    public void Stars()
    {
        if (TransferIndexLevel.transferIndexLevel == 1)
        {
            levelSrarOne = TransferStars.transferStras;
        }
        else if (TransferIndexLevel.transferIndexLevel == 2)
        {
            levelSrarTwo = TransferStars.transferStras;
        }
        else if (TransferIndexLevel.transferIndexLevel == 3)
        {
            levelSrarThree = TransferStars.transferStras;
        }
        else if(TransferIndexLevel.transferIndexLevel == 4)
        {
            levelSrarFour = TransferStars.transferStras;
        }
        else if (TransferIndexLevel.transferIndexLevel == 5)
        {
            levelSrarFive = TransferStars.transferStras;
        }
    }
    public int coins { get; private set; }
}
