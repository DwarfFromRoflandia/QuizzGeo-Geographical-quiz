using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndExit : MonoBehaviour
{
   public void OpenWIndow (GameObject window) => window.SetActive(true);

   public void CloseWindow (GameObject window) => window.SetActive(false);
}
