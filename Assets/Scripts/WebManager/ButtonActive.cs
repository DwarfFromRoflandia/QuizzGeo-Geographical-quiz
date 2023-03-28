using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActive : MonoBehaviour
{
   
    public void ButtonClick()
    {
        GetComponent<Button>().onClick.Invoke();
    }
}
