using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuit
{
    [Test]
    public void TestSuitSimplePasses() //метод, тестирующий совпадение значений двух полей, которые заполняет игрок при регистрации 
    {

        CheckPasswordAndNickname.firstPasswordInRegistartionWindow = "456";
        CheckPasswordAndNickname.secondPasswordInRegistartionWindow = "456";

        Assert.AreEqual(CheckPasswordAndNickname.firstPasswordInRegistartionWindow, CheckPasswordAndNickname.secondPasswordInRegistartionWindow);

    }

    [UnityTest]
    public IEnumerator TestSuitWithEnumeratorPasses() //корутина, тестирующая совпадение тех значений, которые игрок ввводит при регистрации с теми значениями, которые игрок вводит при авторизации
    {

        CheckPasswordAndNickname.passwordInLoginingWindow = "123";
        CheckPasswordAndNickname.passwordInRegistartionWindow = "123";

        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(CheckPasswordAndNickname.passwordInLoginingWindow, CheckPasswordAndNickname.passwordInRegistartionWindow);

        CheckPasswordAndNickname.nicknameInRegistartionWindow = "spider_01";
        CheckPasswordAndNickname.nicknameInLoginingWindow = "spider_01";

        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(CheckPasswordAndNickname.nicknameInRegistartionWindow, CheckPasswordAndNickname.nicknameInLoginingWindow);
        
    }
}
