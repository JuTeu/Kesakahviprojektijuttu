using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class upgradeShop : MonoBehaviour
{
    public int upgrade1dash1Cost, upgrade1dash2Cost;
    public GameObject table;
    public bool upgradeBought;
    public int lastBoughtUpgrade = 0;
    public GameObject infoBox;
    public TextMeshProUGUI infoText;
    private string selectedUpgrade;


    private void Start()
    {
        infoBox.SetActive(false);
    }
    public void unlockUpgrade1()
    {
        if (moneyCounter.allMoney >= upgrade1dash1Cost)
        {
            table.GetComponent<SpriteRenderer>().color = new Color32(255,255,0,100);
            upgradeBought = true;
            lastBoughtUpgrade = 41;
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
            case "Upgrade1-1":
            if (moneyCounter.allMoney >= upgrade1dash1Cost)
            {
                //normal coffee gives 1.25x more money
                makeOrder.normalCoffeePayout = makeOrder.normalCoffeePayout * 1.25f;
                EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
                upgradeBought = true;
                lastBoughtUpgrade = 11;
            }
            else
            {
                Debug.Log("You don't have enough money!");
            }
            break;

            case "Upgrade1-2":
            if (moneyCounter.allMoney >= upgrade1dash2Cost)
            {
                //espressos give 1.25x more money
                makeOrder.espressoPayout = makeOrder.espressoPayout * 1.25f;
                EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
                upgradeBought = true;
                lastBoughtUpgrade = 12;
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
                case 11:
                return upgrade1dash1Cost;

                case 12:
                return upgrade1dash2Cost;
            }
        }
        upgradeBought = false;
        lastBoughtUpgrade = 0;
    return 0;
    }

    public void orderInfos()
    {
        infoBox.SetActive(true);
        selectedUpgrade = EventSystem.current.currentSelectedGameObject.transform.parent.name;
        Debug.Log(EventSystem.current.currentSelectedGameObject.transform.parent.name);
            switch (selectedUpgrade)
            {
                case "placeholder":
                infoText.text = "Placeholder Placeholder Placeholder Placeholder Placeholder Placeholder Placeholder Placeholder Placeholder";
                break;

                case "Upgrade1-1":
                infoText.text = "Normal coffees pay 1.25x more coins!";
                break;
                
                case "Upgrade1-2":
                infoText.text = "Espressos pay 1.25x more coins!";
                break;
            }
    }
    public void closeInfoBox()
    {
        infoBox.SetActive(false);
        selectedUpgrade = "";
    }
}
