using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;


[System.Serializable]
public class DataPlayer
{
    public Player playerData;
    public Error error;
}

[System.Serializable]
public class Player //table data player
{
    public int ID;
    public string nickname;
    public int score;

    public Player (string nickname, int score)
    {
        this.nickname = nickname;
        this.score = score;
    }

    

    public void SetNickName(string nickname) => this.nickname = nickname;
    public void SetScore(int score) => this.score = score;  
}



[System.Serializable]
public class Error 
{
    /*
     класс, который будет возвращать значение при появлении какой-либо ошибки
     будет принимать два параметра: поле string (сообщение об ошибке) и
     поле bool (будет свидетельствовать о том, есть ли вообще ошибка)
     */

    public string errorText;
    public bool isError;

    //public void HundlerError(GameObject loadPanel)
    //{
    //    if (isError) loadPanel.SetActive(true);
    //    else loadPanel.SetActive(false);
    //}
}

public class WebManager : MonoBehaviour
{
    [SerializeField] private string targetURL;
    [SerializeField] private GameObject loadPanel;

    public DataPlayer dataPlayer = new DataPlayer(); //создаём статический экз. класса, чтобы иметь возможность использовать его во всех сценах.
    //public DataPlayer testDataPlayer = new DataPlayer();

    [SerializeField] private UnityEvent OnLogged, OnRegistered;
    


    public enum RequestType
    {
        logging, register, saveNickname, saveScore
    }


    public string GetDataPlayer(DataPlayer data)//метод для сохранения данных класса DataPlayer
    {
        return JsonUtility.ToJson(data);
    }

    public DataPlayer SetDataPlayer(string data)//метод для выгрузки данных из класса DataPlayer
    {
        print(data);
        return JsonUtility.FromJson<DataPlayer>(data);  
    }



    private void Start()
    {
        dataPlayer.error = new Error() { errorText = "Error", isError = true };
        dataPlayer.playerData = new Player("spider_01", 10);

        Debug.Log(GetDataPlayer(dataPlayer));
    }

    private void Update()
    {
        //dataPlayer.error.HundlerError(loadPanel);
    }


    public void Registration(string nickname, string password1, string password2)
    {
        StopAllCoroutines();
        Registering(nickname, password1, password2);
    }
    
    public void Login(string nickname, string password)
    {
        StopAllCoroutines();
        Logging(nickname, password);
    }

    public void SaveNickname(int ID, string nickname)
    {
        StopAllCoroutines();
        NicknameSave(ID, nickname);
    }

    public void SaveScore(int ID, int score)
    {
        StopAllCoroutines();
        ScoreSave(ID, score);
    }

    public void Logging(string nickname, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.logging.ToString()); 
        form.AddField("nickname", nickname);
        form.AddField("password", password);
        StartCoroutine(SendData(form, RequestType.logging));
    }

    public void Registering(string nickname, string password1, string password2)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.register.ToString());
        form.AddField("nickname", nickname);
        form.AddField("password1", password1);
        form.AddField("password2", password2);
        StartCoroutine(SendData(form, RequestType.register));
    }

    public void NicknameSave(int ID, string nickname)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.saveNickname.ToString());
        form.AddField("ID", ID);
        form.AddField("nickname", nickname);
        StartCoroutine(SendData(form, RequestType.saveNickname));
    }

    public void ScoreSave(int ID, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.saveScore.ToString());
        form.AddField("ID", ID);
        form.AddField("score", score);
        StartCoroutine(SendData(form, RequestType.saveScore));
    }

    IEnumerator SendData(WWWForm form, RequestType type)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(targetURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                var data = SetDataPlayer(www.downloadHandler.text);
                //testDataPlayer = data;
                dataPlayer = data;

                if (!data.error.isError)
                {
                    
                    if (type != RequestType.saveNickname && type != RequestType.saveScore)
                    {
                        //dataPlayer = data;
                        if (type == RequestType.logging)
                        {
                            OnLogged.Invoke();
                        }
                        else
                        {
                            OnRegistered.Invoke();
                        }
                    }              
                }

               

                //Debug.Log(SetDataPlayer(www.downloadHandler.text));
                //print(www.downloadHandler.text);
            }
        }
    }

    private void OnEnable()
    {
        if (TestTransfer.idTransfer !=0 && TestTransfer.nicknameTransfer != null & TestTransfer.scoreTransfer != 0)
        {
            dataPlayer.playerData.ID = TestTransfer.idTransfer;
            dataPlayer.playerData.nickname = TestTransfer.nicknameTransfer;
            dataPlayer.playerData.score = TestTransfer.scoreTransfer;
        }
    }

    private void OnDestroy()
    {
        TestTransfer.idTransfer = dataPlayer.playerData.ID;
        TestTransfer.nicknameTransfer = dataPlayer.playerData.nickname;
        TestTransfer.scoreTransfer = dataPlayer.playerData.score;

    }
}
