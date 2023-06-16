using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeShop : MonoBehaviour
{
    public int upgrade1Cost;
    public GameObject table;


    public void unlockUpgrade1()
    {
        if (moneyCounter.allMoney >= upgrade1Cost)
        {
            table.GetComponent<SpriteRenderer>().color = new Color32(255,255,0,100);
        }
    }
}
