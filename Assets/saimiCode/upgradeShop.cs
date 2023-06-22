using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class upgradeShop : MonoBehaviour
{
    public int upgrade1Cost, upgrade2Cost;
    public GameObject table;
    public bool upgradeBought;
    public int lastBoughtUpgrade = 0;
    public void unlockUpgrade1()
    {
        if (moneyCounter.allMoney >= upgrade1Cost)
        {
            table.GetComponent<SpriteRenderer>().color = new Color32(255,255,0,100);
            upgradeBought = true;
            lastBoughtUpgrade = 1;
            EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            Debug.Log("You don't have enough money!");
        }
    }

    public void multiplierUpgrades()
    {
        string selectedupgrade = EventSystem.current.currentSelectedGameObject.name;
        switch (selectedupgrade)
        {
            case "upgrade2":
            if (moneyCounter.allMoney >= upgrade1Cost)
            {
                //normal coffee gives 1.25x more moneyy
                makeOrder.normalCoffeePayout = makeOrder.normalCoffeePayout * 1.25f;
                EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
                upgradeBought = true;
                lastBoughtUpgrade = 2;
            }
            else
            {
                Debug.Log("You don't have enough money!");
            }
            break;
        }
    }

    public int sendUpgradeToCounter()
    {
        if (upgradeBought && lastBoughtUpgrade != 0)
        {
            switch (lastBoughtUpgrade)
            {
                case 1:
                return upgrade1Cost;

                case 2:
                return upgrade2Cost;
            }
        }
        upgradeBought = false;
        lastBoughtUpgrade = 0;
    return 0;
    }
}
