using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SwitchWindow : MonoBehaviour
{
    [Header("Поля для регистрации")]
    [SerializeField] private Text nickRegistrationField;
    [SerializeField] private Text passwordRegistrationField;
    [SerializeField] private Text repeatPasswordRegistrationField;

    private string nickRegistration;
    private string passwordRegistration;
    private string repeatPasswordRegistration;

    [Header("Поля для авторизации")]
    [SerializeField] private Text nickLoggingField;
    [SerializeField] private Text passwordLoggingField;

    private string nickLogging;
    private string passwordLogging;

    [Header("Поля для Кнопки Продолжить")]
    [SerializeField] private Button ContinueRegButton;
    [SerializeField] private Button ContinueLogButton;

    [Header("Окна регистрации и авторизации")]
    [SerializeField] private GameObject RegWindow;
    [SerializeField] private GameObject LogWindow;

    private void Start()
    {
        
    }

    private void Update()
    {
        nickRegistration = nickRegistrationField.text;
        passwordRegistration = passwordRegistrationField.text;
        repeatPasswordRegistration = repeatPasswordRegistrationField.text;

        nickLogging = nickLoggingField.text;
        passwordLogging = passwordLoggingField.text;

        ContinueRegButtonUnavailable();
        ContinueLogButtonUnavailable();


    }

    private bool ContinueRegButtonUnavailable()
    { 

        if (nickRegistration != "" && passwordRegistration != "" && repeatPasswordRegistration != "")
        {
            if (passwordRegistration == repeatPasswordRegistration)
            {
                return ContinueRegButton.interactable = true;
            }       
            return ContinueRegButton.interactable = false;
        }
        else
        {
            return ContinueRegButton.interactable = false;
        }
    }

    private bool ContinueLogButtonUnavailable()
    {
        if (nickLogging != "" && passwordLogging != "")
        {
            if (nickRegistration == nickLogging && repeatPasswordRegistration == passwordLogging)
            {
                return ContinueLogButton.interactable = true;
            }

            return ContinueLogButton.interactable = false;
        }
        else
        {
            return ContinueLogButton.interactable = false;
        }
    }

    public void ContinueActivateButtonAfterReg()
    {
        RegWindow.SetActive(false);
        LogWindow.SetActive(true);
    }
    
    public void ContinueActivateButtonAfterLog() => LogWindow.SetActive(false); 

}
