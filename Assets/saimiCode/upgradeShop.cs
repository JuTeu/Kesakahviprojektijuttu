using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeShop : MonoBehaviour
{
    public int upgrade1Cost;
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
            }
        }
        upgradeBought = false;
        lastBoughtUpgrade = 0;
    return 0;
    }
}
