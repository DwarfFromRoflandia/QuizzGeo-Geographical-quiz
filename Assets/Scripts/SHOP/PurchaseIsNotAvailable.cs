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

    private void AreTheButtonsAvailable()//�����, ���������� �� ��, ����� ������ ������� ������� ��������, � ����� ���.
    {
        IsTheHealthPurchaseButtonAvailable();
        IsTheUsualHintPurchaseButtonAvailable();
        IsTheFiftyFiftyHintPurchaseButtonAvailable();
    }



    private void IsTheHealthPurchaseButtonAvailable()//�����, ���������� �� �������, ����� �������� ������ ������� ������
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
    private void IsTheUsualHintPurchaseButtonAvailable()//�����, ���������� �� �������, ����� �������� ������ ������� ������� ���������
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
    private void IsTheFiftyFiftyHintPurchaseButtonAvailable()//�����, ���������� �� �������, ����� �������� ������ ������� ��������� 50/50
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


    private void CanBuyHealth()//�����, ������� �������� �� ������������ ������� ��� ������� ������� ������
    {
        GoingThroughTheTMPArrayForTheHearts();
        GoingThroughTheInsufficientFundsArrayForTheHearts();
        GoingThroughThePriseArrayForTheHearts();
        GoingThroughTheDiamondsArrayTheHearts();

    }

    private void CanBuyTheUsualHint()//�����, ������� �������� �� ������������ ������� ��� ������� ������� ������� ��������� 
    {
        GoingThroughTheTMPArrayForTheUsualHint();
        GoingThroughTheInsufficientFundsArrayForTheUsualHint();
        GoingThroughThePriseArrayForTheUsualHint();
        GoingThroughTheDiamondsArrayTheUsualHint();

    }

    private void CanBuyTheFiftyFiftyHint()//�����, ������� �������� �� ������������ ������� ��� ������� ������� ��������� 50/50
    {
        GoingThroughTheTMPArrayForTheFiftyFiftyHint();
        GoingThroughTheInsufficientFundsArrayForTheFiftyFiftyHint();
        GoingThroughThePriseArrayForTheFiftyFiftyHint();
        GoingThroughTheDiamondsArrayTheFiftyFiftyHint();
    }



    private void GoingThroughTheTMPArrayForTheHearts()//�����, ���������� �� ����������� ������ �� ������� TMPArray ��� ����������� ������������ �������� ��� ������ 
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

    private void GoingThroughTheInsufficientFundsArrayForTheHearts()//�����, ���������� �� ����������� ������ �� ������� InsufficientFundsArray ��� ����������� ������������ �������� ��� ������ 
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
    private void GoingThroughThePriseArrayForTheHearts()//�����, ���������� �� ����������� ������ �� ������� PriseArray ��� ����������� ������������ �������� ��� ������ 
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
    private void GoingThroughTheDiamondsArrayTheHearts()//�����, ���������� �� ����������� ������ �� ������� DiamondsArray ��� ����������� ������������ �������� ��� ������ 
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

    
    
    
    private void GoingThroughTheTMPArrayForTheUsualHint()//�����, ���������� �� ����������� ������ �� ������� TMPArray ��� ����������� ������������ �������� ��� ������� ��������� 
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
    private void GoingThroughTheInsufficientFundsArrayForTheUsualHint()//�����, ���������� �� ����������� ������ �� ������� InsufficientFundsArray ��� ����������� ������������ �������� ��� ������� ��������� 
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
    private void GoingThroughThePriseArrayForTheUsualHint()//�����, ���������� �� ����������� ������ �� ������� PriseArray ��� ����������� ������������ �������� ��� ������� ��������� 
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
    private void GoingThroughTheDiamondsArrayTheUsualHint()//�����, ���������� �� ����������� ������ �� ������� DiamondsArray ��� ����������� ������������ �������� ��� ������� ��������� 
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




    private void GoingThroughTheTMPArrayForTheFiftyFiftyHint()//�����, ���������� �� ����������� ������ �� ������� TMPArray ��� ����������� ������������ �������� ��� ��������� 50/50
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
    private void GoingThroughTheInsufficientFundsArrayForTheFiftyFiftyHint()//�����, ���������� �� ����������� ������ �� ������� InsufficientFundsArray ��� ����������� ������������ �������� ��� ��������� 50/50
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
    private void GoingThroughThePriseArrayForTheFiftyFiftyHint()//�����, ���������� �� ����������� ������ �� ������� PriseArray ��� ����������� ������������ �������� ��� ��������� 50/50
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
    private void GoingThroughTheDiamondsArrayTheFiftyFiftyHint()//�����, ���������� �� ����������� ������ �� ������� DiamondsArray ��� ����������� ������������ �������� ��� ��������� 50/50
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
