using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;

public class moneyCounter : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    private float moneyToBeAdded = 0;
    public static float allMoney;
    private int successfullOrderTracker = 0;
    private bool addingMoney = true;
    private bool subtractingMoney = false;
    private upgradeShop upgradeShopScript;

    private void Awake()
    {
        moneyText.text = "coins: " + allMoney;
        upgradeShopScript = GameObject.Find("topBar").GetComponent<upgradeShop>();
    }

    //TODO: alota FixedUpdate vasta kun tilausten teko näkymä on avattu.
    //Tää olisi mahdollista (ehkä) gamemanagerista kun hakee levelmanagerin ja levelnamen, mutta
    //tätä ei saanut sen protection levelin takia (juho, mitä tehdä? ensun scriptei ala ite sorkkii etten riko mitää:D)

    private void FixedUpdate()
    {
        addeableMoney();
        updateMoney();
        deleteAddeableMoney();
    }

    private void addeableMoney()
    {
        if (makeOrder.isAnyOrderActive)
        {
            moneyToBeAdded = makeOrder.orderPayout;
        }
    }

    public void updateMoney()
    {
        if (makeOrder.successfullOrders > successfullOrderTracker)
        {
            changeMoney(moneyToBeAdded, addingMoney);
            successfullOrderTracker = makeOrder.successfullOrders;
        }
        else if (upgradeShopScript.upgradeBought && upgradeShopScript.sendUpgradeToCounter() != 0)
        {
            changeMoney(upgradeShopScript.sendUpgradeToCounter(), subtractingMoney);
            upgradeShopScript.upgradeBought = false;
            upgradeShopScript.lastBoughtUpgrade = 0;
        }
    }

    private void deleteAddeableMoney()
    {
        if (!makeOrder.isAnyOrderActive)
        {
            moneyToBeAdded = 0;
        }
    }

    private void changeMoney(float value, bool plusOrMinus)
    {
        if (plusOrMinus)
        {
            allMoney += value;
            moneyText.text = "coins: " + allMoney;
        }
        else
        {
            allMoney -= value;
            moneyText.text = "coins: " + allMoney;
        }
    }
}
