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
     * после того, как я закончу реализацию регистрации игрока
     * нужно будет добавить систему инкремента очков при каждом
     * правильном ответе на вопросы. это можно сделать при помощи статики
     * или Unity Event. Это значение икремента вставить 
     * в метод ChangeScore(), чтобы можно было бы отслеживать актуальное
     * количество очков при прохлждении игры
     */

    private void Start()
    {
        

    }

    private void Update()
    {
        ChangeScore(score);
    }
    public void ChangeScore(int score) // этот метод не будет вызываться по кнопке
    {
        this.score = score;

        webManager.dataPlayer.playerData.score = score;
    }

    public void ChangeNickName(Text nicknameText) // этот метод вызовится по кнопке
    {
        this.nicknameText.text = nicknameText.text;
        //WebManager.dataPlayer.playerData.nickname = nicknameText.text;
        webManager.dataPlayer.playerData.nickname = nicknameText.text;
    }
}
