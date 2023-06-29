using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class topbarNavigation : MonoBehaviour
{
    public GameObject inventory;
    public GameObject collectibles;
    public GameObject upgrades;
    public GameObject returnButton;
    public GameObject collectiblesInfoBox;


    public void upgradeScreen()
    {
        inventory.SetActive(false);
        collectibles.SetActive(false);
        upgrades.SetActive(true);
        returnButton.SetActive(true);
    }
    public void collectiblesScreen()
    {
        inventory.SetActive(false);
        collectibles.SetActive(true);
        collectiblesInfoBox.SetActive(false);
        upgrades.SetActive(false);
        returnButton.SetActive(true);
    }
    public void inventoryScreen()
    {
        inventory.SetActive(true);
        collectibles.SetActive(false);
        upgrades.SetActive(false);
        returnButton.SetActive(true);
    }

    public void returnButtonFunc()
    {
        inventory.SetActive(false);
        collectibles.SetActive(false);
        upgrades.SetActive(false);
        returnButton.SetActive(false);
    }


}
