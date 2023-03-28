using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuantityTextTheUsualHint : MonoBehaviour
{

    private void LateUpdate()
    {
        QuantityTheUsualHintText();
    }

    private string QuantityTheUsualHintText()
    {
        TextMeshProUGUI QuantityTheUsualHintText;
        QuantityTheUsualHintText = GetComponent<TextMeshProUGUI>();
        return QuantityTheUsualHintText.text = TransferTheUsualHint.transferQuantityTheUsualHint.ToString();
    }
}
