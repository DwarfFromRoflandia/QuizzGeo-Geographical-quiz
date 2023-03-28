using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuantityTextTheFiftyFiftyHint : MonoBehaviour
{
    private void LateUpdate()
    {
        QuantityTheFiftyFiftyHintText();
    }

    private string QuantityTheFiftyFiftyHintText()
    {
        TextMeshProUGUI QuantityTheFiftyFiftyHintText;
        QuantityTheFiftyFiftyHintText = GetComponent<TextMeshProUGUI>();
        return QuantityTheFiftyFiftyHintText.text = TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint.ToString();
    }
}
