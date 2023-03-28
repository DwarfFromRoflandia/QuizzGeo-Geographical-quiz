using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCoroutineInTheResultPanelScript : MonoBehaviour
{
    [SerializeField] private Text textPoints;

    [SerializeField] private AnimationOnTheResultPanel animationOnTheResultPanel;

    private int points;
    public int Points { get { return points; } set { points = value; } }  

    private void Update()
    {
        textPoints.text = points.ToString();       
    }
}
