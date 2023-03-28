using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerPrefabHardLevel : SpawnerPrefabLevel
{
    /*������ ������ ����������� �� ������� SpawnerPrefabLevel ��� ����, 
     * ����� ����� ������ � ������ Spawn, ������� � ��� ������ ��� ����� ������. 
     * �������� � ���� ������ � �������� ������, ������� � ����������� ����� ������ �� �����. 
     * ���� ������ ��������� � �������� ������ Spawn, ������ � ������� �� ������ � ��������� �� �������� ����.
     */

    public List<GameObject> PrefabQuestionList = new List<GameObject>();

    private void Awake()
    {
        Spawn(PrefabQuestionList, PullPrefabLevelArray.instance.PullPrefabLevelForForHardLevel);
    }

    private void Update()
    {
        if (EventManager.RemovePrefabHardLevelEvent != null)
        {
            EventManager.RemovePrefabHardLevelEvent.Invoke(PullPrefabLevelArray.instance.PullPrefabLevelForForHardLevel);
        }
    }
}
