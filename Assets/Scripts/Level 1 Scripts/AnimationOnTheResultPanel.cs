using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AnimationOnTheResultPanel : MonoBehaviour
{
    [SerializeField] private AnswerScriptBtn answerScriptBtn;

    [SerializeField] private Animator animationFirstStar;
    [SerializeField] private Animator animationSecondStar;
    [SerializeField] private Animator animationThirdStar;
    [SerializeField] private Animator animatinButton;
    
    [SerializeField] private Animator animationThreeDiamond;
    [SerializeField] private Animator animationSixDiamond;
    [SerializeField] private Animator animationNineDiamond;

    [SerializeField] private Button buttonExitToMenu;

    private CounterOfCorrectAnswer _counterOfCorrectAnswer;
    private StartCoroutineInTheResultPanelScript startCoroutineInTheResultPanelScript;

   // [SerializeField] private EarnedDiamondsText earnedDiamondsText;

    private void Start()
    {
        startCoroutineInTheResultPanelScript = GetComponent<StartCoroutineInTheResultPanelScript>();
        _counterOfCorrectAnswer = transform.root.GetComponent<CounterOfCorrectAnswer>();

        buttonExitToMenu.enabled = false;

        StartAnmationStars();
    }

    public IEnumerator CoroutineAnimationZeroStar(Action callBack)
    {
        Debug.Log("CoroutineAnimationZeroStar");

        yield return new WaitForSeconds(0.5f);
        callBack.Invoke();

        yield return new WaitForSeconds(0.8f);
        buttonExitToMenu.enabled = true;
        Debug.Log("End");
    }

    public IEnumerator CoroutineAnimationOneStar(Action callBack)
    {
        Debug.Log("CoroutineAnimationOneStar");

        yield return new WaitForSeconds(0.5f); 
        animationFirstStar.SetTrigger("AnimFirstStar");


        yield return new WaitForSeconds(1f);
        callBack.Invoke();

        yield return new WaitForSeconds(0.8f);
        buttonExitToMenu.enabled = true;
        Debug.Log("End");
    }

    public IEnumerator CoroutineAnimationTwoStars(Action callBack)
    {
        Debug.Log("CoroutineAnimationTwoStars");

        yield return new WaitForSeconds(0.5f);
        animationFirstStar.SetTrigger("AnimFirstStar");

        yield return new WaitForSeconds(1f);
        animationSecondStar.SetTrigger("AnimSecondStar");

        yield return new WaitForSeconds(1f);
        callBack.Invoke();

        yield return new WaitForSeconds(0.8f);
        buttonExitToMenu.enabled = true;
        Debug.Log("End");
    }

    public IEnumerator CoroutineAnimationThreeStars(Action callBack)
    {
        Debug.Log("CoroutineAnimationThreeStars");

        yield return new WaitForSeconds(0.5f);
        animationFirstStar.SetTrigger("AnimFirstStar");
        Debug.Log("AnimFirstStar");

        yield return new WaitForSeconds(1f);
        animationSecondStar.SetTrigger("AnimSecondStar");
        Debug.Log("AnimSecondStar");

        yield return new WaitForSeconds(1f);
        animationThirdStar.SetTrigger("AnimThirdStar");
        Debug.Log("AnimThirdStar");

        yield return new WaitForSeconds(1f);
        callBack.Invoke();

        yield return new WaitForSeconds(0.8f);
        buttonExitToMenu.enabled = true;
        Debug.Log("End");
    }
    
    private void ExitToMenuAnim()// в теории можно было бы и не использовать тип Action и не засовывать этот метод в него, но я хотел бы чтобы он хоть где-то был (0_o)
    {   
        animatinButton.SetTrigger("ButtonExitToMenu");
    }


    public IEnumerator CoroutineAnimationOfGettingThreeDiamondsEarned()
    {
        Debug.Log("CoroutineAnimationOfGettingThreeDiamondsEarned");
        
        yield return new WaitForSeconds(1f);

        animationThreeDiamond.SetTrigger("ThreeDiamonds");

        //earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;

        yield return new WaitForSeconds(0.45f);

       // earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;

        yield return new WaitForSeconds(0.5f);

       // earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;
    }

    public IEnumerator CoroutineAnimationOfGettingSixDiamondsEarned()
    {
        Debug.Log("CoroutineAnimationOfGettingSixDiamondsEarned");

        yield return new WaitForSeconds(1f);

        animationSixDiamond.SetTrigger("SixDiamonds");

        //earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1; 

        yield return new WaitForSeconds(0.5f);

       // earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;
        
        yield return new WaitForSeconds(0.5f);

        //earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;

        yield return new WaitForSeconds(0.4f);

       // earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;

        yield return new WaitForSeconds(0.4f);

       // earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;

        yield return new WaitForSeconds(0.4f);

       // earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;

    }

    public IEnumerator CoroutineAnimationOfGettingNineDiamondsEarned()
    {
        Debug.Log("CoroutineAnimationOfGettingNineDiamondsEarned");
      
        yield return new WaitForSeconds(1f);

        animationNineDiamond.SetTrigger("NineDiamonds");

       // earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;      

        yield return new WaitForSeconds(0.5f);

        //earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;

        yield return new WaitForSeconds(0.5f);

        //earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;

        yield return new WaitForSeconds(0.5f);

       // earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;

        yield return new WaitForSeconds(0.5f);

        //earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;

        yield return new WaitForSeconds(0.5f);

        //earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;

        yield return new WaitForSeconds(0.4f);

        //earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;

        yield return new WaitForSeconds(0.4f);

        //earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;

        yield return new WaitForSeconds(0.4f);

        //earnedDiamondsText.TextEarnedDiamond(+1);
        startCoroutineInTheResultPanelScript.Points += 1;
    }
    private void StartAnmationStars()
    {
        if (_counterOfCorrectAnswer.CountOfCorrectAnswer >= 0 && _counterOfCorrectAnswer.CountOfCorrectAnswer < 3)
        {
            StartCoroutine(CoroutineAnimationZeroStar(ExitToMenuAnim));
        }

        if (_counterOfCorrectAnswer.CountOfCorrectAnswer >= 3 && _counterOfCorrectAnswer.CountOfCorrectAnswer < 6)
        {
            StartCoroutine(CoroutineAnimationOneStar(ExitToMenuAnim));
        }

        if (_counterOfCorrectAnswer.CountOfCorrectAnswer >= 6 && _counterOfCorrectAnswer.CountOfCorrectAnswer < 9)
        {
            StartCoroutine(CoroutineAnimationTwoStars(ExitToMenuAnim));
        }

        if (_counterOfCorrectAnswer.CountOfCorrectAnswer >= 9)
        {
            StartCoroutine(CoroutineAnimationThreeStars(ExitToMenuAnim));
        }
    }
}
