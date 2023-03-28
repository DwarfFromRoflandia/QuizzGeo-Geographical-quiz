using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UWantOnShop : MonoBehaviour
{
    [SerializeField] private GameObject uWantOnShopPanel;
    [SerializeField] private GameObject ShopMenu;

    private ShopOpenAndExit _shopOpenAndExit;

    private void Start()
    {
        _shopOpenAndExit = GetComponent<ShopOpenAndExit>();
    }

    public void YesHundlerBTN()
    {
        ShopMenu.SetActive(true);
        uWantOnShopPanel.SetActive(false);

        _shopOpenAndExit.IsShopClosed = false;
    }

    public void NoHundlerBTN()
    {
        uWantOnShopPanel.SetActive(false);
    }
}
