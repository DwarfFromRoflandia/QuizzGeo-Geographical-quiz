using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountGem : MonoBehaviour
{
    public Text textGem;

    private int quantityGem; //ÏÅĞÅÌÅÍÍÀß,ÎÒÂÅ×ÀŞÙÀß ÇÀ ÊÎË_ÂÎ ÃÅÌÎÂ ÍÀ ÃËÀÂÍÎÉ ÑÖÅÍÅ
    public int QuantityGem { get {return quantityGem;} set { quantityGem = value; } }

    private void Start()
    {
        Debug.Log("Êîëè÷åñòâî ãåìîâ: " + TransferGem.transferGems);
    }

    private void Update()
    {
        textGem.text = quantityGem.ToString();
        TransferGem.transferGems = quantityGem;
    }

    private void OnEnable()
    {
        if (TransferGem.transferGems != 0) quantityGem = TransferGem.transferGems;
    }

    private void OnDestroy()
    {
        TransferGem.transferGems = quantityGem;
    }
}
