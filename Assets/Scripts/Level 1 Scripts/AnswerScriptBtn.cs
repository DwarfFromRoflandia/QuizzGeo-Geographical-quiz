using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerScriptBtn : MonoBehaviour
{
    [Header("������ �������")]
    [SerializeField] private Button TheFirstAnswerButton;//� ��� ���������� ����������� ������ ������ ������
    [SerializeField] private Button TheSecondAnswerButton;//� ��� ���������� ����������� ������ ������ ������
    [SerializeField] private Button ThirdAnswerButton;//� ��� ���������� ����������� ������ ������ ������
    [SerializeField] private Button TheFourthAnswerButton;//� ��� ���������� ����������� �������� ������ ������


    [Header("����������, ���������� �� �����")]
    [SerializeField] private float timeToWait; //����������, ���������� �� ���������� ������� �������  
    private float WaitTime; //����������, � ������� ����� ������������� � ������ Start() �������� ������� �������
    private bool _isTimer; //��� ���������� ����� �������� �� �������, ����� ��� ����� ����� �������� ������
    public bool _IsTimer { get => _isTimer; }
    

    [Header("�������� ���������� � ������������ �������")]
    private CounterOfCorrectAnswer _counterOfCorrectAnswer;
    private int correctAnswer = 0;
    private int incorrectanswer = 0;
    public int Incorrectanswer { get { return incorrectanswer; } set { incorrectanswer = value; } }


    [Header("�����")]
    private SwitchQuestion _switchQuestion;
    private GreenAndRedLampsList greenAndRedLampsList;


    [Header("������ ����������")]
    [SerializeField] private UIButtonTheFiftyFiftyHint uIButtonTheFiftyFiftyHint;
    public int indexLevel;
    private bool isClick = false;//����������, ������� ��������� ���� �� ������ ������ ������ ���� ���. ���� ��, �� �� ���������� ������� ������ ��������������

    
    private void Start()
    {
        _switchQuestion = transform.parent.parent.GetComponent<SwitchQuestion>();
        greenAndRedLampsList = transform.parent.parent.GetComponent<GreenAndRedLampsList>();

        _counterOfCorrectAnswer = transform.root.GetComponent<CounterOfCorrectAnswer>();

        WaitTime = timeToWait;
        IndexLevel();
        
    }

    private void Update()
    {
        CountClick();
        ActivateTheFiftyFiftyHint();
      
        if (_isTimer) Timer();
    }

    public void RightAnswerHundler()
    {
        Correctly();
        InCorrectly();    
        _isTimer = true;
        isClick = true;
        correctAnswer++;
        _counterOfCorrectAnswer.CountOfCorrectAnswer++;
        TransferValuesForDataBase._Score++;

        if (EventManager.ChangeQuantityScoreEvent != null)
        {
            EventManager.ChangeQuantityScoreEvent.Invoke(TransferValuesForDataBase._Score);
            Debug.Log("����� ������");
        }
        Debug.Log("Answer True");
    }

    public void WrongAnserHundler()
    {
        InCorrectly();
        Correctly();
        _isTimer = true;
        isClick = true;
        incorrectanswer++;
        Debug.Log("Answer False");
    }

    private void Correctly()
    {
        TheSecondAnswerButton.GetComponent<Image>().color = Color.green;       
    }

    private void InCorrectly()
    {
        TheFirstAnswerButton.GetComponent<Image>().color = Color.red;
        ThirdAnswerButton.GetComponent<Image>().color = Color.red;
        TheFourthAnswerButton.GetComponent<Image>().color = Color.red;      
    }

    private void ActivateTheFiftyFiftyHint()
    {
        if (uIButtonTheFiftyFiftyHint.ActivatedTheFiftyFiftyHint)
        {
            ThirdAnswerButton.GetComponent<Image>().color = Color.red;
            TheFourthAnswerButton.GetComponent<Image>().color = Color.red;

            ThirdAnswerButton.enabled = false;
            TheFourthAnswerButton.enabled = false;
        }
    }

    private void Timer()
    {
        WaitTime -= Time.deltaTime;
        if (WaitTime <= 0)
        {            
            WaitTime = timeToWait;
            SwitchGreenLamp();
            SwitchRedLamp();
            _isTimer = false;
            _switchQuestion.countQuestion++;
            
        }
    }

   
    private void CountClick()//�����, ���������� �� ��, ��� ����� �������������� ������ � ������ ������-���� ������
    {
        if (isClick)
        {
            TheFirstAnswerButton.enabled = false;
            TheSecondAnswerButton.enabled = false;
            ThirdAnswerButton.enabled = false;
            TheFourthAnswerButton.enabled = false;
        }
    }

    public void SwitchGreenLamp()
    {
        for (int i = 0; i < greenAndRedLampsList.GreenLampList.Count; i++)
        {
            switch (_switchQuestion.countQuestion)
            {
                case 0:
                    if (correctAnswer == 1) greenAndRedLampsList.GreenLampList[0].SetActive(true);
                    break;
                case 1:
                    if (correctAnswer == 1) greenAndRedLampsList.GreenLampList[1].SetActive(true);
                    break;
                case 2:
                    if (correctAnswer == 1) greenAndRedLampsList.GreenLampList[2].SetActive(true);
                    break;
                case 3:
                    if (correctAnswer == 1) greenAndRedLampsList.GreenLampList[3].SetActive(true);
                    break;
                case 4:
                    if (correctAnswer == 1) greenAndRedLampsList.GreenLampList[4].SetActive(true);
                    break;
                case 5:
                    if (correctAnswer == 1) greenAndRedLampsList.GreenLampList[5].SetActive(true);
                    break;
                case 6:
                    if (correctAnswer == 1) greenAndRedLampsList.GreenLampList[6].SetActive(true);
                    break;
                case 7:
                    if (correctAnswer == 1) greenAndRedLampsList.GreenLampList[7].SetActive(true);
                    break;
                case 8:
                    if (correctAnswer == 1) greenAndRedLampsList.GreenLampList[8].SetActive(true);
                    break;
                case 9:
                    if (correctAnswer == 1) greenAndRedLampsList.GreenLampList[9].SetActive(true);
                    break;

                default:
                    break;
            }
        }
        
    }

    public void SwitchRedLamp()
    {
        for (int i = 0; i < greenAndRedLampsList.RedLampList.Count; i++)
        {
            switch (_switchQuestion.countQuestion)
            {
                case 0:
                    if (incorrectanswer == 1) greenAndRedLampsList.RedLampList[0].SetActive(true);
                    break;
                case 1:
                    if (incorrectanswer == 1) greenAndRedLampsList.RedLampList[1].SetActive(true);
                    break;
                case 2:
                    if (incorrectanswer == 1) greenAndRedLampsList.RedLampList[2].SetActive(true);
                    break;
                case 3:
                    if (incorrectanswer == 1) greenAndRedLampsList.RedLampList[3].SetActive(true);
                    break;
                case 4:
                    if (incorrectanswer == 1) greenAndRedLampsList.RedLampList[4].SetActive(true);
                    break;
                case 5:
                    if (incorrectanswer == 1) greenAndRedLampsList.RedLampList[5].SetActive(true);
                    break;
                case 6:
                    if (incorrectanswer == 1) greenAndRedLampsList.RedLampList[6].SetActive(true);
                    break;
                case 7:
                    if (incorrectanswer == 1) greenAndRedLampsList.RedLampList[7].SetActive(true);
                    break;
                case 8:
                    if (incorrectanswer == 1) greenAndRedLampsList.RedLampList[8].SetActive(true);
                    break;
                case 9:
                    if (incorrectanswer == 1) greenAndRedLampsList.RedLampList[9].SetActive(true);
                    break;

                default:
                    break;
            }
        }
    }
   
    private void IndexLevel()
    {
        TransferIndexLevel.transferIndexLevel = SceneManager.GetActiveScene().buildIndex;

        Debug.Log("Get active scine in a level: " + TransferIndexLevel.transferIndexLevel);
    }

    private void OnEnable()
    {
        if (TransferIndexLevel.transferIndexLevel != 0)
        {
            indexLevel = TransferIndexLevel.transferIndexLevel;
        }
    }

    private void OnDestroy()
    {
        TransferIndexLevel.transferIndexLevel = indexLevel;
    }
}
