using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class PlayerBuilder : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private WebManager webManager;    
    [SerializeField] private Text nicknameText;
    public int Score { get { return score; } set { score = value; } }
    /*
     * ����� ����, ��� � ������� ���������� ����������� ������
     * ����� ����� �������� ������� ���������� ����� ��� ������
     * ���������� ������ �� �������. ��� ����� ������� ��� ������ �������
     * ��� Unity Event. ��� �������� ��������� �������� 
     * � ����� ChangeScore(), ����� ����� ���� �� ����������� ����������
     * ���������� ����� ��� ����������� ����
     */

    private void Start()
    {
        

    }

    private void Update()
    {
        ChangeScore(score);
    }
    public void ChangeScore(int score) // ���� ����� �� ����� ���������� �� ������
    {
        this.score = score;

        webManager.dataPlayer.playerData.score = score;
    }

    public void ChangeNickName(Text nicknameText) // ���� ����� ��������� �� ������
    {
        this.nicknameText.text = nicknameText.text;
        //WebManager.dataPlayer.playerData.nickname = nicknameText.text;
        webManager.dataPlayer.playerData.nickname = nicknameText.text;
    }
}
