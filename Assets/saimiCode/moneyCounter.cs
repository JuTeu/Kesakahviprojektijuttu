using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using unity.UI;

public class moneyCounter : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    private int moneyToBeAdded;
    private int allMoney;

    private void addeableMoney()
    {
        if (makeOrder.instance.isAnyOrderActive)
        {
            moneyToBeAdded = makeOrder.instance.orderPayout;
        }
    }

    private void updateMoney()
    {
        if (makeOrder.instance.success().isCalled)
        {
            addMoney(moneyToBeAdded)
        }
    }

    private void deleteAddeableMoney()
    {
        if (!makeOrder.instance.isAnyOrderActive)
        {
            moneyToBeAdded = 0;
        }
    }

    private void addMoney(int value)
    {
        allMoney += value;
        moneyText.text = "coins: " + allMoney;
    }
}
