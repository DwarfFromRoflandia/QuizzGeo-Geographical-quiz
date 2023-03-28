using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPlayBtn : MonoBehaviour
{
   
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameModeMenu;  
    public void StartHundler()
    {
        gameModeMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
}
