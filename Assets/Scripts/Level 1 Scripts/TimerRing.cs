 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TimerRing : MonoBehaviour
{
    [SerializeField] private UIButtonTheUsualHint uiButtonTheUsualHint;

    [SerializeField] private Image timerRing;//� ��� ���������� ����������� �������� ������ �������
    [SerializeField] private float gametime;//� ��� ���������� � ��������� unity ����� ������������� �������� ������� ��� �������
    
    private AnswerScriptBtn answerScriptBtn;//����������, ������� ����� ��� ����, ����� ����� ����������� �������� � �������� � ����������� �� ������� AnswerBtn

    private SwitchQuestion _switchQuestion;
    
    private float ontime;//����������, � ������� ����� ������������ �������� ������� �������

    private bool isTimer = true;//����������, ������� �������� �� ��, �������� ��� ������ ��� ���
    public bool IsTimer { get => isTimer; }

    private void Start()
    {
        answerScriptBtn = GetComponent<AnswerScriptBtn>();//���� ��������� �� ���������, �.�. ��� ���� ������, ��� ������ AnswerScriptBtn ����� �� ����� ������� �������
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
        
        if (answerScriptBtn._IsTimer == false && isTimer == true)//���� �� ���� ����� �� ������ ������� � ��� ���� �� ������ �� ������ ������, �� ������ ��������
        {
            ontime -= Time.deltaTime;
            timerRing.fillAmount = ontime / gametime;
            isTimer = true;
        }
        else if(answerScriptBtn._IsTimer == true)//���� �� ������ �� ������ ������, �� ������ ���������� isTimer false � ��� ����� ������ ���������� ���� ������
        {
            isTimer = false;
        }     
    }

    private void TimerStop()
    {
        if (ontime < 0f)//����� �������� ������� ������ 0, �� ���������� ����� �� ������� AnswerScriptBtn, ������� ����������� ������
        {
            isTimer = false;
            answerScriptBtn.Incorrectanswer++;
            answerScriptBtn.SwitchRedLamp();
            _switchQuestion.countQuestion++;            
            Debug.Log("Time is out");
        }
    }
}
