using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBtnScript : MonoBehaviour
{
    public void ExitHundler()
    {
        Application.Quit();
        Debug.Log("Exit");
    } 
}
