using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Products : MonoBehaviour
{


    public Button _BuyTheUsualHint;
    public Button _BuyTheFiftyFiftyHint;


    [SerializeField] private TextMeshProUGUI quantityTheUsualHintText;
    [SerializeField] private TextMeshProUGUI multiplierTheUsualHintText;
    
    private int quantityTheUsualHint;
    public int QuantityTheUsualHint { get { return quantityTheUsualHint; } set { quantityTheUsualHint = value; } }

    [SerializeField] private TextMeshProUGUI quantityTheFiftyFiftyHintText;
    [SerializeField] private TextMeshProUGUI multiplierTheFiftyFiftyHintText;
    
    private int quantityTheFiftyFiftyHint;
    public int QuantityTheFiftyFiftyHint { get { return quantityTheFiftyFiftyHint; } set { quantityTheFiftyFiftyHint = value; } }

    [SerializeField] private HeartsVersionTwo _hearts;
    [SerializeField] private TimerHearts _timerHearts;

    [SerializeField] private PageSwaperShop pageSwaperShop;

    [SerializeField] private Animator animationTheUsualHint;
    [SerializeField] private Animator animationTheFiftyFiftyHint;
    [SerializeField] private Animator animationHearts;

    [SerializeField] private ShopOpenAndExit shopOpenAndExit;

    [SerializeField] private Animator quantityAnimationTheUsualHint;
    [SerializeField] private Animator quantityAnimationTheFiftyFiftyHint;

    [SerializeField] private CountGem _countGem;


    private const float  timeOnOffNumber = 1f; //ВРЕМЯ РАБОТЫ КОРУТИНЫ ЗАВИСИТ ОТ ВРЕМЕНИ АНИМАЦИИ ТОВАРОВ

    private bool coroutineBuyTheUsualHint = false;
    private bool coroutineBuyFiftyFiftyHint = false;
    
    public bool PropCoroutineBuyTheUsualHint { get { return coroutineBuyTheUsualHint; } set { coroutineBuyTheUsualHint = value; } }
    public bool PropCoroutineBuyFiftyFiftyHint { get { return coroutineBuyFiftyFiftyHint; } set { coroutineBuyFiftyFiftyHint = value; } }

    private bool isHeartsRecovered = false;
    public bool IsheartsRecovered { get { return isHeartsRecovered; } set { isHeartsRecovered = value; } }



    private void Update()
    {
        RestoringHearts();
        
        TransferTheUsualHint.transferQuantityTheUsualHint = quantityTheUsualHint;
        TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint = quantityTheFiftyFiftyHint;
    }

    private void LateUpdate() //используем здесь метод LateUpdate для того, чтобы анимация успевала обновляться в то время, когда игрок заходит в магазин
    {
        IsCoroutineBuyTheUsualHint();
        IsCoroutineBuyFiftyFiftyHint();

        SetDisabledTheUsualHintText();
        SetDisabledTheFiftyFiftyHintText();

        //AnimationOfTheFirstProduct();
        //AnimationOfTheFiftyFiftyHint();
        //AnimationHearts();
        AnimationProducts();


    }


    public void ByeTheUsualHint()
    {
        Debug.Log("Bye The Usual Hint");
        SetQuantityTheUsualHint();

        StartCoroutine(CoroutineBuyTheUsualHint());
        quantityAnimationTheUsualHint.SetTrigger("ClickBTN");

        _countGem.QuantityGem -= PurchaseIsNotAvailable.PriseTheUsualHint;
    }

   public void ByeTheFiftyFiftyHint()
   {
        Debug.Log("Bye The Fifty-Fifty Hint");
        SetQuantityTheFiftyFiftyHint();

        StartCoroutine(CoroutineTheFiftyFiftyHint());
        quantityAnimationTheFiftyFiftyHint.SetTrigger("BuyTheFiftyFiftyHint");

        _countGem.QuantityGem -= PurchaseIsNotAvailable.PriseTheFiftyFiftyHint;
   }

    public void ByeHealth()
    {
        isHeartsRecovered = true;

        _timerHearts.StopTimer();
        
        Debug.Log("Bye Health");

        _countGem.QuantityGem -= PurchaseIsNotAvailable.PriseHealth;

        _hearts.HeartOneFull.fillAmount = 1;
        _hearts.HeartTwoFull.fillAmount = 1;
        _hearts.HeartThreeFull.fillAmount = 1;   
    }

    private void RestoringHearts()
    {
        if (isHeartsRecovered)
        {
            _hearts.QuantityHearts = 3;
            _hearts.IsFullHearts = true;
            _hearts.IsTwoHearts = false;
            _hearts.IsOneHearts = false;
            _hearts.NoHearts = false;
        }
    }

    private string SetQuantityTheUsualHint()
    {
        quantityTheUsualHint++;
        Debug.Log("Количество обычных подсказок: " + quantityTheUsualHint);
        return quantityTheUsualHintText.text = quantityTheUsualHint.ToString();     
    }

    private string SetQuantityTheFiftyFiftyHint()
    {
        quantityTheFiftyFiftyHint++;
        Debug.Log("Количество подсказок 50/50: " + quantityTheFiftyFiftyHint);
        return quantityTheFiftyFiftyHintText.text = quantityTheFiftyFiftyHint.ToString();
            
    }



    public IEnumerator CoroutineBuyTheUsualHint()
    {     
        Debug.Log("Начало корутины TheUsualHint");
        coroutineBuyTheUsualHint = true;

        SetEnabledTheUsualHintText();

        yield return new WaitForSeconds(timeOnOffNumber);

        coroutineBuyTheUsualHint = false;
        
        SetDisabledTheUsualHintText(); 
    }

    public IEnumerator CoroutineTheFiftyFiftyHint()
    {
        Debug.Log("Начало корутины TheFiftyFiftyHint");
        coroutineBuyFiftyFiftyHint = true;

        SetEnabledTheFiftyFiftyHintText();

        yield return new WaitForSeconds(timeOnOffNumber);

        coroutineBuyFiftyFiftyHint = false;
        
        SetDisabledTheFiftyFiftyHintText();    
    }

    private void IsCoroutineBuyTheUsualHint()
    {
        if (coroutineBuyTheUsualHint)
            _BuyTheUsualHint.enabled = false;
    }

    private void IsCoroutineBuyFiftyFiftyHint()
    {
        if (coroutineBuyFiftyFiftyHint)
             _BuyTheFiftyFiftyHint.enabled = false;    
    }

    private void AnimationProducts()
    {
        switch (pageSwaperShop.CurrentPage)
        {
            case 1:
                if (!shopOpenAndExit.IsShopClosed) animationTheUsualHint.SetBool("AnimationTheUsualHint", true);
                break;
            case 2:
                if (!shopOpenAndExit.IsShopClosed) animationTheFiftyFiftyHint.SetBool("AnimationTheFiftyFiftyHint", true);
                break;
            case 3:
                if (!shopOpenAndExit.IsShopClosed) animationHearts.SetBool("AnimationHearts", true);
                break;
            default:
                break;
        }
    }

    //private void AnimationOfTheFirstProduct()
    //{
    //    if (pageSwaperShop.CurrentPage == 1)
    //        animationTheUsualHint.SetBool("AnimationTheUsualHint", true);
    //    else if (shopOpenAndExit.IsShopClosed == true)
    //        animationTheUsualHint.SetBool("AnimationTheUsualHint", false);
    //}

    //private void AnimationOfTheFiftyFiftyHint()
    //{
    //    if (pageSwaperShop.CurrentPage == 2)
    //        animationTheFiftyFiftyHint.SetBool("AnimationTheFiftyFiftyHint", true);
    //    else if (shopOpenAndExit.IsShopClosed == true)
    //        animationTheFiftyFiftyHint.SetBool("AnimationTheFiftyFiftyHint", false);
    //}

    //private void AnimationHearts()
    //{
    //    if (pageSwaperShop.CurrentPage == 3)
    //        animationHearts.SetBool("AnimationHearts", true);
    //    else if (shopOpenAndExit.IsShopClosed == true)
    //        animationHearts.SetBool("AnimationHearts", false);
    //}
    private void SetDisabledTheUsualHintText()
    {
        if (!coroutineBuyTheUsualHint)
        {
            quantityTheUsualHintText.gameObject.SetActive(false);
            multiplierTheUsualHintText.gameObject.SetActive(false);
        }       
    }

    private void SetDisabledTheFiftyFiftyHintText()
    {
        if (!coroutineBuyFiftyFiftyHint)
        {
            quantityTheFiftyFiftyHintText.gameObject.SetActive(false);
            multiplierTheFiftyFiftyHintText.gameObject.SetActive(false);
        }
    }

    private void SetEnabledTheUsualHintText()
    {
        quantityTheUsualHintText.gameObject.SetActive(true);
        multiplierTheUsualHintText.gameObject.SetActive(true);
    }

    private void SetEnabledTheFiftyFiftyHintText()
    {
        quantityTheFiftyFiftyHintText.gameObject.SetActive(true);
        multiplierTheFiftyFiftyHintText.gameObject.SetActive(true);
    }


    private void OnEnable()
    {
        if (TransferTheUsualHint.transferQuantityTheUsualHint != 0)
        {
            quantityTheUsualHint = TransferTheUsualHint.transferQuantityTheUsualHint;
        }
        if (TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint != 0)
        {
            quantityTheFiftyFiftyHint = TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint;
        }
    }

    private void OnDestroy()
    {
        TransferTheUsualHint.transferQuantityTheUsualHint = quantityTheUsualHint;
        TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint = quantityTheFiftyFiftyHint;
    }
}
