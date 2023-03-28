using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullPrefabLevelArray
{
    /*
     ������ ������� ���� ����� ��������� ��� �������(����� ���� ������ ������ �� ����, ������� ����� ����� ������� � ����). 
     ���� ���������� ������ ����. ������ ������ ����� ��������� � ���� ������� �������, ����������� ��� ����������� ���� �������.
     �������� �� ������ ������� ����� ������������� � �������, ������� ����������� � �������. ��� �����, ��������� �����, � �������
     ����� ���������� � ��������� ������� ������� ������� � ������� ���������� �������, ����������� ��� ����������� �������.
     */


    public List<GameObject> PullPrefabLevelForSimpleLevel = new List<GameObject>();
    public List<GameObject> PullPrefabLevelForLimitedTimeLevel = new List<GameObject>();
    public List<GameObject> PullPrefabLevelForForHardLevel = new List<GameObject>();

    //���������� ������� ��������, ������� �������� ���������� ������ �������� � ������ ����� (����� � ��������).
    public static PullPrefabLevelArray instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PullPrefabLevelArray();
            }
            return _instance;
        }
    }

    private static PullPrefabLevelArray _instance;
}
