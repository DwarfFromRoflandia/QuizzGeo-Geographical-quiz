using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPrefabSimpleLevel : SpawnerPrefabLevel
{
    /*������ ������ ����������� �� ������� SpawnerPrefabLevel ��� ����, 
     * ����� ����� ������ � ������ Spawn, ������� � ��� ������ ��� ����� ������. 
     * �������� � ���� ������ � �������� ������, ������� � ����������� ����� ������ �� �����. 
     * ���� ������ ��������� � �������� ������ Spawn, ������ � ������� �� ������ � ��������� �� �������� ����.
     */

    public List<GameObject> PrefabQuestionList = new List<GameObject>();
    private void Awake()
    {
       Spawn(PrefabQuestionList, PullPrefabLevelArray.instance.PullPrefabLevelForSimpleLevel);
    }

    private void Update()
    {
        if (EventManager.RemovePrefabSimpleLevelEvent != null)
        {
            EventManager.RemovePrefabSimpleLevelEvent.Invoke(PullPrefabLevelArray.instance.PullPrefabLevelForSimpleLevel);
        }
    }


}
