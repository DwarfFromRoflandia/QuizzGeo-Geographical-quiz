using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenu : MonoBehaviour
{
    [SerializeField] private GameObject ExitCanvas;

    public void ExitMenuOn()
    {
        ExitCanvas.SetActive(true);
    }

    public void ExitMenuOf()
    {
        ExitCanvas.SetActive(false);
    }
}
