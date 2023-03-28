using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpenAndExit : MonoBehaviour
{
    [SerializeField] private GameObject panelShop;

    [SerializeField] private GameObject _uWantOnShop;

    [SerializeField] private Products products;

    private bool isShopClosed = true;
    public bool IsShopClosed { get { return isShopClosed; } set { isShopClosed = value; } }

    private void Update()
    {
        ForcedShutdownCoroutines();
    }

    public void OpenHundler()
    {
        _uWantOnShop.SetActive(true);
    }
    public void ExitHundler()
    {
        panelShop.SetActive(false);
        products.IsheartsRecovered = false;
        isShopClosed = true;  
    } 

    private void ForcedShutdownCoroutines()
    {
        if (isShopClosed)
        {
            products.PropCoroutineBuyTheUsualHint = false;
            products.PropCoroutineBuyFiftyFiftyHint = false;
        }
    }
}
