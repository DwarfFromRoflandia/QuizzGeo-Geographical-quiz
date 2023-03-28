using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarnedDiamondsText : MonoBehaviour
{
    private Text textDiamonds;


    private void Start()
    {
        textDiamonds = GetComponent<Text>();
    }

    private void Update()
    {
        TextEarnedDiamond(0);
    }

    public int TextEarnedDiamond(int points)
    {
        textDiamonds.text = points.ToString();
        return points;
    }
}
