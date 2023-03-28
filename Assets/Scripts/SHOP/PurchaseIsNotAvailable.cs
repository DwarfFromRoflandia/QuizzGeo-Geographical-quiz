using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PurchaseIsNotAvailable : MonoBehaviour
{
    [SerializeField] private CountGem _quantityGem;
    [SerializeField] private TimerHearts _timerHearts;

    public TextMeshProUGUI[] TMPArray;
    public TextMeshProUGUI[] InsufficientFundsArray;
    public TextMeshProUGUI[] Prise;
    public Image[] Diamonds;

    public const int PriseTheUsualHint = 2; 
    public const int PriseTheFiftyFiftyHint = 4; 
    public const int PriseHealth = 5;

    public Button _BuyTheUsualHint;
    public Button _BuyTheFiftyFiftyHint;
    public Button _BuyHealth;

    private void LateUpdate()
    {
        AreTheButtonsAvailable();

        CanBuyHealth();

        CanBuyTheFiftyFiftyHint();

        CanBuyTheUsualHint();
    }

    private void AreTheButtonsAvailable()//метод, отвечающий за то, когда кнопки покупки товаров доступны, а когда нет.
    {
        IsTheHealthPurchaseButtonAvailable();
        IsTheUsualHintPurchaseButtonAvailable();
        IsTheFiftyFiftyHintPurchaseButtonAvailable();
    }



    private void IsTheHealthPurchaseButtonAvailable()//метод, отвечающий за условие, когда доступна кнопка покупки жизней
    {
        if (_timerHearts.IsTimer)
        {
            if (_quantityGem.QuantityGem < PriseHealth)
            {
                _BuyHealth.enabled = false;
            }
            else
            {
                _BuyHealth.enabled = true;
            }
        }
        else
        {
            _BuyHealth.enabled = false;
        }
    }
    private void IsTheUsualHintPurchaseButtonAvailable()//метод, отвечающий за условие, когда доступна кнопка покупки обычной подсказки
    {
        if (_quantityGem.QuantityGem < PriseTheUsualHint)
        {
            _BuyTheUsualHint.enabled = false;
        }
        else
        {
            _BuyTheUsualHint.enabled = true;
        }
    }
    private void IsTheFiftyFiftyHintPurchaseButtonAvailable()//метод, отвечающий за условие, когда доступна кнопка покупки подсказки 50/50
    {
        if (_quantityGem.QuantityGem < PriseTheFiftyFiftyHint)
        {
            _BuyTheFiftyFiftyHint.enabled = false;
        }
        else
        {
            _BuyTheFiftyFiftyHint.enabled = true;
        }
    }


    private void CanBuyHealth()//Метод, который отвечает за подсказочные надписи под кнопкой покупки жизней
    {
        GoingThroughTheTMPArrayForTheHearts();
        GoingThroughTheInsufficientFundsArrayForTheHearts();
        GoingThroughThePriseArrayForTheHearts();
        GoingThroughTheDiamondsArrayTheHearts();

    }

    private void CanBuyTheUsualHint()//Метод, который отвечает за подсказочные надписи под кнопкой покупки обычной подсказки 
    {
        GoingThroughTheTMPArrayForTheUsualHint();
        GoingThroughTheInsufficientFundsArrayForTheUsualHint();
        GoingThroughThePriseArrayForTheUsualHint();
        GoingThroughTheDiamondsArrayTheUsualHint();

    }

    private void CanBuyTheFiftyFiftyHint()//Метод, который отвечает за подсказочные надписи под кнопкой покупки подсказки 50/50
    {
        GoingThroughTheTMPArrayForTheFiftyFiftyHint();
        GoingThroughTheInsufficientFundsArrayForTheFiftyFiftyHint();
        GoingThroughThePriseArrayForTheFiftyFiftyHint();
        GoingThroughTheDiamondsArrayTheFiftyFiftyHint();
    }



    private void GoingThroughTheTMPArrayForTheHearts()//метод, отвечающий за прохождение циклом по массиву TMPArray для отображения подсказочных надписей для жизней 
    {
        for (int i = 0; i < TMPArray.Length; i++)
        {
            if (_timerHearts.IsTimer)
            {
                if (_quantityGem.QuantityGem < PriseHealth)
                {
                    TMPArray[2].gameObject.SetActive(false);
                }
                else
                {
                    TMPArray[2].gameObject.SetActive(true);
                }

                TMPArray[3].gameObject.SetActive(false);
            }
            else
            {
                TMPArray[2].gameObject.SetActive(false);
                TMPArray[3].gameObject.SetActive(true);

            }
        }
    }

    private void GoingThroughTheInsufficientFundsArrayForTheHearts()//метод, отвечающий за прохождение циклом по массиву InsufficientFundsArray для отображения подсказочных надписей для жизней 
    {
        for (int i = 0; i < InsufficientFundsArray.Length; i++)
        {

            if (_timerHearts.IsTimer)
            {
                if (_quantityGem.QuantityGem < PriseHealth)
                {
                    InsufficientFundsArray[2].gameObject.SetActive(true);
                }
                else
                {
                    InsufficientFundsArray[2].gameObject.SetActive(false);
                }
            }
            else
            {
                InsufficientFundsArray[2].gameObject.SetActive(false);
            }
        }
    }
    private void GoingThroughThePriseArrayForTheHearts()//метод, отвечающий за прохождение циклом по массиву PriseArray для отображения подсказочных надписей для жизней 
    {
        for (int i = 0; i < Prise.Length; i++)
        {
            if (_timerHearts.IsTimer)
            {
                if (_quantityGem.QuantityGem < PriseHealth)
                {
                    Prise[2].gameObject.SetActive(false);
                }
                else
                {
                    Prise[2].gameObject.SetActive(true);
                }
            }
            else
            {
                Prise[2].gameObject.SetActive(false);
            }
        }
    }
    private void GoingThroughTheDiamondsArrayTheHearts()//метод, отвечающий за прохождение циклом по массиву DiamondsArray для отображения подсказочных надписей для жизней 
    {
        for (int i = 0; i < Diamonds.Length; i++)
        {
            if (_timerHearts.IsTimer)
            {
                if (_quantityGem.QuantityGem < PriseHealth)
                {
                    Diamonds[2].gameObject.SetActive(false);
                }
                else
                {
                    Diamonds[2].gameObject.SetActive(true);
                }
            }
            else
            {
                Diamonds[2].gameObject.SetActive(false);
            }
        }
    }

    
    
    
    private void GoingThroughTheTMPArrayForTheUsualHint()//метод, отвечающий за прохождение циклом по массиву TMPArray для отображения подсказочных надписей для обычной подсказки 
    {
        for (int i = 0; i < TMPArray.Length; i++)
        {
            if (_quantityGem.QuantityGem < PriseTheUsualHint)
            {
                TMPArray[0].gameObject.SetActive(false);
            }
            else if (_quantityGem.QuantityGem >= PriseTheUsualHint)
            {
                TMPArray[0].gameObject.SetActive(true);
            }
        }
    }
    private void GoingThroughTheInsufficientFundsArrayForTheUsualHint()//метод, отвечающий за прохождение циклом по массиву InsufficientFundsArray для отображения подсказочных надписей для обычной подсказки 
    {
        for (int i = 0; i < InsufficientFundsArray.Length; i++)
        {
            if (_quantityGem.QuantityGem < PriseTheUsualHint)
            {
                InsufficientFundsArray[0].gameObject.SetActive(true);
            }
            else if (_quantityGem.QuantityGem >= PriseTheUsualHint)
            {
                InsufficientFundsArray[0].gameObject.SetActive(false);
            }
        }
    }
    private void GoingThroughThePriseArrayForTheUsualHint()//метод, отвечающий за прохождение циклом по массиву PriseArray для отображения подсказочных надписей для обычной подсказки 
    {
        for (int i = 0; i < Prise.Length; i++)
        {
            if (_quantityGem.QuantityGem < PriseTheUsualHint)
            {
                Prise[0].gameObject.SetActive(false);
            }
            else if (_quantityGem.QuantityGem >= PriseTheUsualHint)
            {
                Prise[0].gameObject.SetActive(true);
            }
        }
    }
    private void GoingThroughTheDiamondsArrayTheUsualHint()//метод, отвечающий за прохождение циклом по массиву DiamondsArray для отображения подсказочных надписей для обычной подсказки 
    {
        for (int i = 0; i < Diamonds.Length; i++)
        {
            if (_quantityGem.QuantityGem < PriseTheUsualHint)
            {
                Diamonds[0].gameObject.SetActive(false);
            }
            else if (_quantityGem.QuantityGem >= PriseTheUsualHint)
            {
                Diamonds[0].gameObject.SetActive(true);
            }
        }
    }




    private void GoingThroughTheTMPArrayForTheFiftyFiftyHint()//метод, отвечающий за прохождение циклом по массиву TMPArray для отображения подсказочных надписей для подсказки 50/50
    {
        for (int i = 0; i < TMPArray.Length; i++)
        {
            if (_quantityGem.QuantityGem < PriseTheFiftyFiftyHint)
            {
                TMPArray[1].gameObject.SetActive(false);
            }
            else if (_quantityGem.QuantityGem >= PriseTheFiftyFiftyHint)
            {
                TMPArray[1].gameObject.SetActive(true);
            }
        }
    }
    private void GoingThroughTheInsufficientFundsArrayForTheFiftyFiftyHint()//метод, отвечающий за прохождение циклом по массиву InsufficientFundsArray для отображения подсказочных надписей для подсказки 50/50
    {
        for (int i = 0; i < InsufficientFundsArray.Length; i++)
        {
            if (_quantityGem.QuantityGem < PriseTheFiftyFiftyHint)
            {
                InsufficientFundsArray[1].gameObject.SetActive(true);
            }
            else if (_quantityGem.QuantityGem >= PriseTheFiftyFiftyHint)
            {
                InsufficientFundsArray[1].gameObject.SetActive(false);
            }
        }
    }
    private void GoingThroughThePriseArrayForTheFiftyFiftyHint()//метод, отвечающий за прохождение циклом по массиву PriseArray для отображения подсказочных надписей для подсказки 50/50
    {
        for (int i = 0; i < Prise.Length; i++)
        {
            if (_quantityGem.QuantityGem < PriseTheFiftyFiftyHint)
            {
                Prise[1].gameObject.SetActive(false);
            }
            else if (_quantityGem.QuantityGem >= PriseTheFiftyFiftyHint)
            {
                Prise[1].gameObject.SetActive(true);
            }
        }
    }
    private void GoingThroughTheDiamondsArrayTheFiftyFiftyHint()//метод, отвечающий за прохождение циклом по массиву DiamondsArray для отображения подсказочных надписей для подсказки 50/50
    {
        for (int i = 0; i < Diamonds.Length; i++)
        {
            if (_quantityGem.QuantityGem < PriseTheFiftyFiftyHint)
            {
                Diamonds[1].gameObject.SetActive(false);
            }
            else if (_quantityGem.QuantityGem >= PriseTheFiftyFiftyHint)
            {
                Diamonds[1].gameObject.SetActive(true);
            }
        }
    }
}
