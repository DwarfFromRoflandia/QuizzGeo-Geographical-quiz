using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CounterAnswer : MonoBehaviour
{
    private CounterOfCorrectAnswer _counterOfCorrectAnswer;//эта переменная будет использоваться для того, чтобы подсчитывать количество звёзд на самом уровне в скрипте StarsCount

    private AnimationOnTheResultPanel animationOnTheResultPanel;

    private void Start()
    {       
        _counterOfCorrectAnswer = transform.root.GetComponent<CounterOfCorrectAnswer>();
        animationOnTheResultPanel = GetComponent<AnimationOnTheResultPanel>();
        TransferStars.transferStras = _counterOfCorrectAnswer.CountOfCorrectAnswer;//будем присваивать в значение transferStras, значение score для того, чтобы игрок в меню выбора уровней видел, сколько он звёзд собрад за тот или иной уровень
        CountTransferGem();
    }

    private void CountTransferGem()
    {
        if (_counterOfCorrectAnswer.CountOfCorrectAnswer < 3)
        {      
            Debug.Log("*********0*********"); 
        }
        else if (_counterOfCorrectAnswer.CountOfCorrectAnswer >= 3 && _counterOfCorrectAnswer.CountOfCorrectAnswer < 6)
        {
            Bank.instance.PlusThreeGem();

            
            animationOnTheResultPanel.StartCoroutine(animationOnTheResultPanel.CoroutineAnimationOfGettingThreeDiamondsEarned());
            Debug.Log("*********3*********");
        }
        else if(_counterOfCorrectAnswer.CountOfCorrectAnswer >= 6 && _counterOfCorrectAnswer.CountOfCorrectAnswer < 9)
        {
            Bank.instance.PlusSixGem();

            animationOnTheResultPanel.StartCoroutine(animationOnTheResultPanel.CoroutineAnimationOfGettingSixDiamondsEarned());
            Debug.Log("*********6*********");
        }
        else if (_counterOfCorrectAnswer.CountOfCorrectAnswer >= 9)
        {
            Bank.instance.PlusNineGem();

            animationOnTheResultPanel.StartCoroutine(animationOnTheResultPanel.CoroutineAnimationOfGettingNineDiamondsEarned());
            Debug.Log("*********9*********");
        }
    }
}

