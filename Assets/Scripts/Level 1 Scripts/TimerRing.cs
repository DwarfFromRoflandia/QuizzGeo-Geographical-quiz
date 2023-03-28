 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TimerRing : MonoBehaviour
{
    [SerializeField] private UIButtonTheUsualHint uiButtonTheUsualHint;

    [SerializeField] private Image timerRing;//в эту переменную присваиваем картинку нашего таймера
    [SerializeField] private float gametime;//в эту переменную в редакторе unity будет присваиваться значение времени для таймера
    
    private AnswerScriptBtn answerScriptBtn;//переменная, которая нужна для того, чтобы иметь возможность работать с методами и переменными из скрипта AnswerBtn

    private SwitchQuestion _switchQuestion;
    
    private float ontime;//переменная, в которую будет передаваться значение времени таймера

    private bool isTimer = true;//переменная, которая отвечает за то, работает наш таймер или нет
    public bool IsTimer { get => isTimer; }

    private void Start()
    {
        answerScriptBtn = GetComponent<AnswerScriptBtn>();//берём компонент по соседству, т.к. что этот скрипт, что скрипт AnswerScriptBtn лежат на одном игровом объекте
        _switchQuestion = transform.parent.parent.GetComponent<SwitchQuestion>();
        ontime = gametime;
    }

    private void Update()
    {
        RignTimer();
        TimerStop();
    }

    private void RignTimer()
    {
        
        if (answerScriptBtn._IsTimer == false && isTimer == true)//если мы дали добро на роботу таймера и при этом не нажали на кнопку ответа, то таймер работает
        {
            ontime -= Time.deltaTime;
            timerRing.fillAmount = ontime / gametime;
            isTimer = true;
        }
        else if(answerScriptBtn._IsTimer == true)//если мы нажали на кнопку ответа, то делаем переменную isTimer false и тем самым таймер прекращает свою работу
        {
            isTimer = false;
        }     
    }

    private void TimerStop()
    {
        if (ontime < 0f)//когда значение таймера меньше 0, то вызывается метод из скрипта AnswerScriptBtn, который переключает вопрос
        {
            isTimer = false;
            answerScriptBtn.Incorrectanswer++;
            answerScriptBtn.SwitchRedLamp();
            _switchQuestion.countQuestion++;            
            Debug.Log("Time is out");
        }
    }
}
