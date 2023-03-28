using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TestButton : MonoBehaviour
{
    public void LoadTestScene()
    {
        SceneManager.LoadScene(6);

        //if (EventManager.SpawnQuestionEvent != null)
        //{
        //    EventManager.SpawnQuestionEvent.Invoke();
        //    Debug.Log("Instantiate");
        //}
    }
}
