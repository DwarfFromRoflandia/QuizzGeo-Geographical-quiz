using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnerPrefabLevel : MonoBehaviour
{
    /*
    ������ ������ �� �������� �� � ������ �������. �� �������� �����, ������� ���������� � ������ ���������� Spawner. 
    ������ ����� �������� � ���� ��� ���������. ������ �������� � ������������ ������ ������� �������� �� ���������� �� ����� ������� ������. 
    ������ �������� � ������������ ������, ������� �������� ������� ����� �������� �������� � ������� ���� � � ����� ������(������ ��������) 
    � ������� ��������� ������������ ������ ������ � ������, ������� ��������� � ����� ������(������ ��������).
     */

    //public List<GameObject> PrefabQuestionList = new List<GameObject>(); //PrefabQuestionList == CloneQuestionsList

    //private void Awake()
    //{

    //}   

    public static GameObject prefabLevel;
    protected void Spawn(List<GameObject> PrefabQuestionList, List<GameObject> PullPrefabLevel)
    {
        //mainObject = GameObject.FindGameObjectWithTag("MainObject");
        
        int randomQuestion;

        //���� ���� ���������� 10 ��� � �� �������� ��������� ������ QuestionList ����������� ���������� � ��������� �������, ������������ ���� �� �����.
        for (int i = 0; i < 1; i++)
        {
            do
            {
                randomQuestion = Random.Range(0, PullPrefabLevel.Count);//� ���������� randomQuestion ����������� ��������� �������� �� 0 �� ���� ����� ������
            }
            while (PrefabQuestionList.Contains(PullPrefabLevel[randomQuestion]));//����� Contains() ����� true � ��� ������, ���� ������ ����� ����������� ������� (������ �������� ����� �������� ���������� randomQuestion)
            {
                PrefabQuestionList.Add(PullPrefabLevel[randomQuestion]);
            }
            prefabLevel = PullPrefabLevel[randomQuestion];
            Debug.Log("PullPrefabLevel: " + prefabLevel);
        }

        for (int i = 0; i < 1; i++)
        {
            Instantiate(PrefabQuestionList[0]);//��� ������ ���� ������ ������ �� �����
        }



        Debug.Log("���������� ��������� � ����� QuestionList: " + PrefabQuestionList.Count);
    }
}
