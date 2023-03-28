using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabLevelArray : MonoBehaviour
{
    /*
     ������ ������� ���� ����� ��������� ��� �������(����� ���� ������ ������ �� ����, ������� ����� ����� ������� � ����). 
     ���� ���������� ������ ����. ������ ������ ����� ��������� � ���� ������� �������, ����������� ��� ����������� ���� �������.
     �������� (������� GameObject'��) �� ������ �������� ����� ������������� � ������ �������, ����������� ��� �� ����� �������.
     */


    public List<GameObject> PrefabLevelArrayForSimpleLevel = new List<GameObject>();

    public List<GameObject> PrefabLevelArrayForLimitedTimeLevel = new List<GameObject>();

    public List<GameObject> PrefabLevelArrayForHardLevel = new List<GameObject>();

    public static bool isActivateAssignment = false; //����������, ������� ������� � ���, ����������� �� ������� �� �������� �� ������� ������ � ����������� ������� �������� �������


    void Start()
    {
        
        if (!isActivateAssignment)
        {
            PullPrefabLevelArray.instance.PullPrefabLevelForSimpleLevel = PrefabLevelArrayForSimpleLevel;
            PullPrefabLevelArray.instance.PullPrefabLevelForLimitedTimeLevel = PrefabLevelArrayForLimitedTimeLevel;
            PullPrefabLevelArray.instance.PullPrefabLevelForForHardLevel = PrefabLevelArrayForHardLevel;
            isActivateAssignment = true;
        }
        else
        {
            PrefabLevelArrayForSimpleLevel = PullPrefabLevelArray.instance.PullPrefabLevelForSimpleLevel;
            PrefabLevelArrayForLimitedTimeLevel = PullPrefabLevelArray.instance.PullPrefabLevelForLimitedTimeLevel;
            PrefabLevelArrayForHardLevel = PullPrefabLevelArray.instance.PullPrefabLevelForForHardLevel;
        }

        Debug.Log("isActivateAssignment: " + isActivateAssignment);
        //Debug.Log("� ������ ���� " + PullPrefabLevelArray.instance.PullPrefabLevelForSimpleLevel.Count);

    }
}
