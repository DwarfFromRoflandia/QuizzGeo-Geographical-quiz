using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameModeMenu;
    [SerializeField] private GameObject _mainMenu;
    public void BackmenuHundler()
    {
        _gameModeMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
