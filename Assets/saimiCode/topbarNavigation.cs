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
    public GameObject[] upgradesPages;


    public void upgradeScreen()
    {
        inventory.SetActive(false);
        collectibles.SetActive(false);
        upgrades.SetActive(true);
        returnButton.SetActive(true);
        upgradesPages[0].SetActive(true);
        for (int i = 1; i < upgradesPages.Length; i++)
        {
            upgradesPages[i].SetActive(false);
        }
    }
    public void collectiblesScreen()
    {
        inventory.SetActive(false);
        collectibles.SetActive(true);
        collectiblesInfoBox.SetActive(false);
        upgrades.SetActive(false);
        returnButton.SetActive(true);
        foreach (GameObject pages in upgradesPages)
        {
            pages.SetActive(false);
        }
    }
    public void inventoryScreen()
    {
        inventory.SetActive(true);
        collectibles.SetActive(false);
        upgrades.SetActive(false);
        returnButton.SetActive(true);
        foreach (GameObject pages in upgradesPages)
        {
            pages.SetActive(false);
        }
    }

    public void returnButtonFunc()
    {
        inventory.SetActive(false);
        collectibles.SetActive(false);
        upgrades.SetActive(false);
        returnButton.SetActive(false);
        foreach (GameObject pages in upgradesPages)
        {
            pages.SetActive(false);
        }
    }

    public void upgradesNextPage()
    {
        int index = 0;
        for (int i = 0; i < upgradesPages.Length; i++)
        {
            if (upgradesPages[i].activeSelf == true)
            {
                index = i;
            }
        }
        foreach (GameObject pages in upgradesPages)
        {
            pages.SetActive(true);
        }
        upgradesPages[index].SetActive(false);
    }
}
