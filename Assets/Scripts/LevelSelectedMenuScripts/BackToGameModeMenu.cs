using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToGameModeMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelSelected;
    
    public void BackToMenuHundler()
    {
        levelSelected.SetActive(false);       
    }    
}
