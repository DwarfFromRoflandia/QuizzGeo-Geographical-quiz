using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�������� ���������
    //��������(������ ���, ������� �� ����� �������, � �� ������ ����) ������ ���� ����� ���� � �� �� ������ ������ �����������. �.�. �� ������ ���� ����� ����
    public static GameManager instance { get; private set; }

    private void Awake()
    {
        
        //������ �������� ����� ��� ����, ��� ���� �� ������� ��� ��������� � ������������� GameManager, �� ������(�.�. ����) GameManager ����� ����������, �.�. ��  DontDestroy, � ������ ��������� � ������ ��������� �� ���������
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);//������ ������� ��������� �� ���������� GAmeManager, ����� �� ��������� �� ������ �����
            return;
        }

        Destroy(this.gameObject);
    
    
    
    }

}
