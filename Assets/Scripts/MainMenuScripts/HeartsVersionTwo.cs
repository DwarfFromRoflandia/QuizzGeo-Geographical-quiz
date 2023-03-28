using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsVersionTwo : MonoBehaviour
{   
    [SerializeField] private GameObject ShopMenu; //� ��� ���������� � ��������� ��� ����������� ������ ��������

    //���������� � ������� ����������� ������� ������
    public Image HeartOneFull;
    public Image HeartTwoFull;
    public Image HeartThreeFull;

    public Image HeartOneEmpty;
    public Image HeartTwoEmpty;
    public Image HeartThreeEmpty;

    public GameObject PanelTimerHealth;//���������� � ������� ����� ����������� ������ �������

    private int quantityHearts;// ���������� � ������� ����� ������������� ����� ���������� ������ ������
    public int QuantityHearts { get { return quantityHearts; } set { quantityHearts = value; } }
    
    private TimerHearts timer;
    

    //��������� ����������, ���������� �� ��, �������, ����� ����� ������� ������� ������
    private bool isFullHearts = false;
    public bool IsFullHearts { get { return isFullHearts; } set { isFullHearts = value; } }

    private bool isTwoHearts = false;
    public bool IsTwoHearts { get { return isTwoHearts; } set { isTwoHearts = value; } }

    private bool isOneHearts = false;
    public bool IsOneHearts { get { return isOneHearts; } set { isOneHearts = value; } }

    private bool noHearts = false;
    public bool NoHearts { get { return noHearts; } set { noHearts = value; } }

    private void Start()
    {
        timer = GetComponent<TimerHearts>();
    }

    //������ ����� ��������� �� ������ ����� � ������� TimerHearts, ������� ��������� ������
    private void Update()
    {
        timer.HeartsTimer();

        DestructionHearts();

        TransferHearts.transferHearts = quantityHearts;
    }

    private void LateUpdate()
    {
        if (timer.IsTimer == true) PanelTimerHealth.SetActive(true);
    }

    //�����, ���������� �� �������� ������ ��� ����������� �������(���������� ������� � �������� ��������� ����������)
    private void DestructionHearts() 
    {
        if (quantityHearts == 3)
        {          
            HeartThreeFull.gameObject.SetActive(true);
            HeartTwoFull.gameObject.SetActive(true);
            HeartOneFull.gameObject.SetActive(true);

            isFullHearts = true;
            noHearts = false;
        }
        if (quantityHearts <= 2 && timer.IsTimer == false)
        {
            HeartThreeFull.gameObject.SetActive(false);

            isTwoHearts = true;
            isFullHearts = false;         
        }
        if (quantityHearts <= 1 && timer.IsTimer == false)
        {
            HeartTwoFull.gameObject.SetActive(false);

            isOneHearts = true;
            isTwoHearts = false;
        }
        if (quantityHearts == 0 && timer.IsTimer == false)
        {
            HeartOneFull.gameObject.SetActive(false);

            noHearts = true;
            isOneHearts = false;

            timer.IsTimer = true;          
        }
    }

    //��� ������ ���� ��������� ����������� � ������� �������� � ���������� quantityHearts
    private void OnEnable()
    {
        if (TransferHearts.transferHearts != 0)
        {
            quantityHearts = TransferHearts.transferHearts;
        }
    }

    private void OnDestroy()
    {
        TransferHearts.transferHearts = quantityHearts;
    }
}
