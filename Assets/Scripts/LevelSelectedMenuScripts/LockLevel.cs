using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�����, ������� ����� �����������, ��� ������� ������� ������������ �������� �������: https://www.youtube.com/watch?v=AQpDtrNJAEU&t=1130s

public class LockLevel : MonoBehaviour
{
    public Button[] LevelButtons;
    public GameObject[] Locks;
    public GameObject[] LevelText;

    private int levelReached;//������ ���������� ���������� ����������� �������. � ������ ������������ ������ ������, �������� ���� ���������� ����� ������������� �� �������, ��� �������� ��������� ������ �� �������
    public int LevelReached { get { return levelReached; } set { levelReached = value; } }   
    
    public Button[] UnavailableLevels;//************������� ���� ������ �����,����� ����� ����� ��������� ������ � ������ ������ �������� � �������� ������� �� ����� � ������� ������ �� ������� ������ ������************////

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
            //���� � ���� ������� ������(������ ������) ���� ������ ������, �������� �� ��� �� ��������, �� ����� ������� ��� ������ ���������������
            if (i + 1 > levelReached)//��, �������, ��� ������ ���������� � ����, �, ��������, ��� ����������� ������� ���������� � �������, ������� �� ������ ������ �������� ������� � ������, ����� ������� ��� ��������� ��������������
            {
                LevelButtons[i].interactable = false;

            }
            if (i + 1 < levelReached)//�������, ��������� �������� ����������� ������ �������, ������� ������ �����
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
        for (int i = 0; i < UnavailableLevels.Length; i++)//************������� ���� ���� �����,����� ����� ����� ��������� ������ � ������ ������ �������� � �������� ������� �� ����� � ������� ������ �� ������� ������ ������ ************//
        {
            UnavailableLevels[i].interactable = false;
        }
    }
}
