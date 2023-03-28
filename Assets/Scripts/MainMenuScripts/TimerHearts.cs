using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//ссылка на ролик о том, как сделать этот таймер: https://www.youtube.com/watch?v=HLz_k6DSQvU

public class TimerHearts : MonoBehaviour
{  
    [SerializeField] private Text timerText;
    [SerializeField] private float startMinutes; //данная переменная задаёт начальное значение 
    [SerializeField] private Button btnBigGeoTrip;

    [SerializeField] private Animator animatorFirstHeart;
    [SerializeField] private Animator animatorSecondHeart;
    [SerializeField] private Animator animatorThirdHeart;

    [SerializeField] private Products products;

    private float timeUntilTheFirstHeartRestored = 200;//200
    private float timeUntilTheSecondHeartRestored = 100; //100
    private float timeUntilTheThirdHeartRestored = 10;  //10


    private HeartsVersionTwo hearts;
    
    public float ontime;

    private bool isTimer  = false;

    public bool IsTimer { get { return isTimer;} set { isTimer = value; } }
 
    public void StopTimer()
    {
        isTimer = false;
        ontime = startMinutes;
        hearts.PanelTimerHealth.SetActive(false);
    }

    //метод самого таймера
    public void HeartsTimer()
    {
        if (isTimer)
        {
            ontime -= Time.deltaTime;
            if (ontime < 0f)
            {
                isTimer = false;
                ontime = startMinutes;
            }
            RecoveryHearts();
            AnimationRecoveryOfTheFirstHeart();
            AnimationRecoveryOfTheSecondHeart();
            AnimationRecoveryOfTheThirdHeart();
        }
        TimeSpan time = TimeSpan.FromSeconds(ontime); //данной строчкой мы будем конвертировать секунды в минуты
        timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();//задаём формат нашего таймера
    }
    private void Start()
    {
        hearts = GetComponent<HeartsVersionTwo>();
        ontime = startMinutes * 60f; //в переменной currentTime будем хранить текущее значение в секундах                        
    }

    //метод, который восстанавливает сердца
    private void RecoveryHearts()
    {  
        if (ontime <= timeUntilTheFirstHeartRestored)
        {         
            hearts.NoHearts = false;
            hearts.IsOneHearts = true;

            hearts.QuantityHearts = 1;           
        }
        if (ontime <= timeUntilTheSecondHeartRestored)
        {
            hearts.IsOneHearts = false;
            hearts.IsTwoHearts = true;      

            hearts.QuantityHearts = 2;
        }
        if (ontime <= timeUntilTheThirdHeartRestored)
        {
            hearts.IsTwoHearts = false;
            hearts.IsFullHearts = true;

            hearts.QuantityHearts = 3;  

            StopTimer();
        }
    }

    private void AnimationRecoveryOfTheFirstHeart()
    {
        if (ontime >= timeUntilTheFirstHeartRestored)
        {
            hearts.HeartOneFull.gameObject.SetActive(true);
            hearts.HeartTwoFull.gameObject.SetActive(false);
            hearts.HeartThreeFull.gameObject.SetActive(false);            
        }

        animatorFirstHeart.SetBool("TheRecoveringFirstHeart", hearts.NoHearts == true);
    }

    private void AnimationRecoveryOfTheSecondHeart()
    {
        if (ontime >= timeUntilTheSecondHeartRestored && ontime < timeUntilTheFirstHeartRestored)
        {
            hearts.HeartOneFull.gameObject.SetActive(true);
            hearts.HeartTwoFull.gameObject.SetActive(true);
            hearts.HeartThreeFull.gameObject.SetActive(false);           
        }
        animatorSecondHeart.SetBool("TheRecoveringSecondHeart", hearts.IsOneHearts == true);

    }

    private void AnimationRecoveryOfTheThirdHeart()
    {
        if (ontime >= timeUntilTheThirdHeartRestored && ontime < timeUntilTheSecondHeartRestored)
        {
            hearts.HeartOneFull.gameObject.SetActive(true);
            hearts.HeartTwoFull.gameObject.SetActive(true);
            hearts.HeartThreeFull.gameObject.SetActive(true);          
        }
        animatorThirdHeart.SetBool("TheRecoveringThirdHeart", hearts.IsTwoHearts == true);
    }       
}
