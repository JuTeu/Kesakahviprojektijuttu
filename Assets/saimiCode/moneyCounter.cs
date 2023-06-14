using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;

public class moneyCounter : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    private int moneyToBeAdded = 0;
    private int allMoney;
    private int successfullOrderTracker = 0;

    private void addeableMoney()
    {
        if (makeOrder.instance.isAnyOrderActive)
        {
            moneyToBeAdded = makeOrder.instance.orderPayout;
        }
    }

    private void updateMoney()
    {
        if (makeOrder.instance.successfullOrders > successfullOrderTracker)
        {
            addMoney(moneyToBeAdded);
            successfullOrderTracker = makeOrder.instance.successfullOrders;
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
