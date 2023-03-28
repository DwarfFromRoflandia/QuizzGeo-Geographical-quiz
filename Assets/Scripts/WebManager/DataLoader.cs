using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour
{
    [SerializeField] private InputField nameInput;
    [SerializeField] private PlayerBuilder _score;
    [SerializeField] private WebManager webManager;

    private RegistrationMenu _registrationMenu;
    private SaveDataForDataBase saveDataForDataBase;

    private void Start()
    {
        _registrationMenu = GetComponent<RegistrationMenu>();
        saveDataForDataBase = GetComponent<SaveDataForDataBase>();
    }

    public void LoadData()
    {
        nameInput.text = webManager.dataPlayer.playerData.nickname;
        _score.Score = webManager.dataPlayer.playerData.score;
    }

    private void Update()
    {
        //SaveData();

        if (saveDataForDataBase.IsChangeScoreInDataBase)
        {
            SaveChangedScore();
            saveDataForDataBase.IsChangeScoreInDataBase = false;
        }
    }

    public void SaveChangedNickname() //разделить этот метод на два. Score должны сохраняться в отдельном методе
    {
        var player = webManager.dataPlayer.playerData;
        webManager.SaveNickname(player.ID, player.nickname);
    }

    public void SaveChangedScore() //разделить этот метод на два. Score должны сохраняться в отдельном методе
    {
        var player = webManager.dataPlayer.playerData;
        webManager.SaveScore(player.ID, player.score);

        //_registrationMenu.Login();

        Debug.Log("SaveChangedScore()");
    }
}
