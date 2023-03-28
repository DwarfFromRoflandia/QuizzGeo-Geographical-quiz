using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPasswordAndNickname : MonoBehaviour
{
    [SerializeField] private Text passwordInReg;
    [SerializeField] private Text passwordInLog;

    [SerializeField] private Text nicknameInReg;
    [SerializeField] private Text nicknameInLog;

    [SerializeField] private Text FirstPasswordInReg;
    [SerializeField] private Text SecondPasswordInReg;

    public static string passwordInRegistartionWindow;
    public static string passwordInLoginingWindow;

    public static string nicknameInRegistartionWindow;
    public static string nicknameInLoginingWindow;

    public static bool closeLoginWindow = false;
    public static bool closeRegistrationWindow = false;

    public static string firstPasswordInRegistartionWindow;
    public static string secondPasswordInRegistartionWindow;

    private void Update()
    {
        //passwordInLog.text = passwordInLoginingWindow;
        //passwordInReg.text = passwordInRegistartionWindow;

        passwordInLoginingWindow = passwordInLog.text;
        passwordInRegistartionWindow = passwordInReg.text;

        nicknameInRegistartionWindow = nicknameInReg.text;
        nicknameInLoginingWindow = nicknameInLog.text;

        firstPasswordInRegistartionWindow = FirstPasswordInReg.text;
        secondPasswordInRegistartionWindow = SecondPasswordInReg.text;
    }

   
}
