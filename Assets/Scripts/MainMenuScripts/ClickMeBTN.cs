using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMeBTN : MonoBehaviour
{
    public void LevelOne()
    {
        Debug.Log("���������� Bank.instance.levelSrarOne: " + Bank.instance.levelSrarOne);
        Debug.Log("TransferStars: " + TransferStars.transferStras);
    }

    public void LevelTwo()
    {
        Debug.Log("���������� Bank.instance.levelSrarTwo: " + Bank.instance.levelSrarTwo);
        Debug.Log("TransferStars: " + TransferStars.transferStras);
    }

    public void LevelThree()
    {
        Debug.Log("���������� Bank.instance.levelSrarThree: " + Bank.instance.levelSrarThree);
        Debug.Log("TransferStars: " + TransferStars.transferStras);
    }

    public void LevelFour()
    {
        Debug.Log("���������� Bank.instance.levelSrarFour: " + Bank.instance.levelSrarFour);
        Debug.Log("TransferStars: " + TransferStars.transferStras);
    }

    public void LevelFive()
    {
        Debug.Log("���������� Bank.instance.levelSrarFive: " + Bank.instance.levelSrarFive);
        Debug.Log("TransferStars: " + TransferStars.transferStras);
    }

    public void IndexLevel()
    {
        Debug.Log("IndexLevel �����: " + TransferIndexLevel.transferIndexLevel);
    }
}
