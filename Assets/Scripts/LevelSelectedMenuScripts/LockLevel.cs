using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ролик, который помог разобраться, как сделать систему постепенного открытия уровней: https://www.youtube.com/watch?v=AQpDtrNJAEU&t=1130s

public class LockLevel : MonoBehaviour
{
    public Button[] LevelButtons;
    public GameObject[] Locks;
    public GameObject[] LevelText;

    private int levelReached;//данная переменная обозначает достигнутый уровень. С каждым прохождением нового уровня, значение этой переменной будет увеличиваться на единицу, что позволит открывать уровни по порядку
    public int LevelReached { get { return levelReached; } set { levelReached = value; } }   
    
    public Button[] UnavailableLevels;//************УДАЛИТЬ ЭТОТ МАССИВ ТОГДА,КОГДА НУЖНО БУДЕТ ЗАПОЛНЯТЬ ВТОРУЮ И ТРЕТЬЮ ПАНЕЛЬ УРОВНЯМИ И ЗАМЕНИТЬ ЗАМОЧКИ НА ТЕКСТ С НОМЕРОМ УРОВНЯ НА СПРАЙТЕ САМОГО УРОВНЯ************////

    private void Start()
    {   
        levelReached = 1;

        if (TransferValueLevelToUnlock.valueLevelToUnlock > levelReached) levelReached = TransferValueLevelToUnlock.valueLevelToUnlock;
 
        IsTheLevelButtonAvailable();
        OpenTheLocks();
        ShowLevelNumber();
        OtherUnavailableLevels();
    }

    private void IsTheLevelButtonAvailable()
    {
        for (int i = 0; i < LevelButtons.Length; i++)
        {
            //если у этой текущей кнопки(кнопки уровня) есть индекс уровня, которого мы еще не достигли, мы хотим сделать эту кнопку неинтерактивной
            if (i + 1 > levelReached)//но, конечно, наш индекс начинается с нуля, и, очевидно, наш достигнутый уровень начинается с единицы, поэтому мы должны просто добавить единицу в индекс, чтобы сделать это полностью действительным
            {
                LevelButtons[i].interactable = false;

            }
            if (i + 1 < levelReached)//условие, благодаря которому блокируются кнопки уровней, которые прошёл игрок
            {
                LevelButtons[i].enabled = false;
            }
        }
    }

    private void OpenTheLocks()
    {
        for (int i = 0; i < Locks.Length; i++)
        {
            Locks[i].SetActive(true);

            if (LevelButtons[i + 1].interactable == true)
            {
                Locks[i].SetActive(false);
            }
        }
    }

    private void ShowLevelNumber()
    {
        for (int i = 0; i < LevelText.Length; i++)
        {
            LevelText[i].SetActive(false);

            if (LevelButtons[i + 1].interactable == true)
            {
                LevelText[i].SetActive(true);
            }
        }
    }

    private void OtherUnavailableLevels()
    {
        for (int i = 0; i < UnavailableLevels.Length; i++)//************УДАЛИТЬ ЭТОТ ЦИКЛ ТОГДА,КОГДА НУЖНО БУДЕТ ЗАПОЛНЯТЬ ВТОРУЮ И ТРЕТЬЮ ПАНЕЛЬ УРОВНЯМИ И ЗАМЕНИТЬ ЗАМОЧКИ НА ТЕКСТ С НОМЕРОМ УРОВНЯ НА СПРАЙТЕ САМОГО УРОВНЯ ************//
        {
            UnavailableLevels[i].interactable = false;
        }
    }
}
