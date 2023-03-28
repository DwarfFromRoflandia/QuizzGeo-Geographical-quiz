using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPrefabLimitedTimeLevel : SpawnerPrefabLevel
{
    /*������ ������ ����������� �� ������� SpawnerPrefabLevel ��� ����, 
     * ����� ����� ������ � ������ Spawn, ������� � ��� ������ ��� ����� ������. 
     * �������� � ���� ������ � �������� ������, ������� � ����������� ����� ������ �� �����. 
     * ���� ������ ��������� � �������� ������ Spawn, ������ � ������� �� ������ � ��������� �� �������� ����.
     */

    public List<GameObject> PrefabQuestionList = new List<GameObject>();

    private void Awake()
    {
        Spawn(PrefabQuestionList, PullPrefabLevelArray.instance.PullPrefabLevelForLimitedTimeLevel);
    }

    private void Update()
    {
        if (EventManager.RemovePrefabLimitedTimeLevelEvent != null)
        {
            EventManager.RemovePrefabLimitedTimeLevelEvent.Invoke(PullPrefabLevelArray.instance.PullPrefabLevelForLimitedTimeLevel);
        }
    }
}
