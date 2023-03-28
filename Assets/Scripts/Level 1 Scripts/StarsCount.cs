using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsCount : MonoBehaviour
{    
    [Header("¬ключЄнные звЄзды")]
    [SerializeField] private GameObject star1On;
    [SerializeField] private GameObject star2On;
    [SerializeField] private GameObject star3On;

    private int countStar;
    public int CountStars { get => countStar; }

    private CounterOfCorrectAnswer _counterOfCorrectAnswer;

    private void Start()
    {
        _counterOfCorrectAnswer = transform.root.GetComponent<CounterOfCorrectAnswer>();
        CountStar();
    }

    public void CountStar()
    {
        if (_counterOfCorrectAnswer.CountOfCorrectAnswer >= 3 && _counterOfCorrectAnswer.CountOfCorrectAnswer < 6)
        {
            star1On.SetActive(true);

            countStar += 3;

        }
        if (_counterOfCorrectAnswer.CountOfCorrectAnswer >= 6 && _counterOfCorrectAnswer.CountOfCorrectAnswer < 9)
        {
            star1On.SetActive(true);
            star2On.SetActive(true);

            countStar += 6;

        }
        if (_counterOfCorrectAnswer.CountOfCorrectAnswer >= 9)
        {
            star1On.SetActive(true);
            star2On.SetActive(true);
            star3On.SetActive(true);

            countStar += 9;

        }   
    }
    private void OnEnable()
    {
        if (TransferStars.transferStras != 0)
        {
            countStar = TransferStars.transferStras;
        }
    }

    private void OnDestroy()
    {
        TransferStars.transferStras = countStar;
    }
}
