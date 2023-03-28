using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimationUsingUsualHint : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private TextMeshProUGUI hint;
    
    [SerializeField] private Animator animationQuestion;
    [SerializeField] private Animator animationHint;
     
    public void ActivateUsualHint()
    {
        animationQuestion.SetTrigger("OffQuestion");
        animationHint.SetTrigger("OnHint");
    }

    public void NoActivateUsualHint()
    {        
        animationQuestion.SetTrigger("OnQuestion");
        animationHint.SetTrigger("OffHint");
    }
}
