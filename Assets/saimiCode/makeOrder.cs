using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class makeOrder : MonoBehaviour
{
    public GameObject chooseCup;
    public GameObject chooseOrder;
    public GameObject chooseBean;
    public GameObject chooseMilk;
    private string latteRecipe = "L1M"; //L for latte, 1 for bean type1, FM for frothed milk
    private string playerRecipe = "";
    private string selectedOrder = "";

    private void Start()
    {
        chooseOrder.SetActive(true);
        chooseCup.SetActive(false);
        chooseBean.SetActive(false);
        chooseMilk.SetActive(false);
    }
    public void acceptOrder()
    {
        if (this.gameObject.name == "OrderLatte")
        {
            makeLatte();
        }
    }

    private void makeLatte()
    {
        latteMaking();
    }

    public void latteMaking()
    {
        chooseOrder.SetActive(false);
        chooseCup.SetActive(true);
        selectedOrder = "Latte";
    }

    public void chooseCorrectCup(Button btn)
    {
        if (btn.name == "latteCup")
        {
            playerRecipe = string.Concat(playerRecipe, 'L');
        }
        else if (btn.name =="normalCup")
        {
            playerRecipe = string.Concat(playerRecipe, 'N');;
        }
        switch (selectedOrder)
        {
            case "Latte":
            if (compareRecipes(latteRecipe, playerRecipe) == false)
            {
                Debug.Log("Wrong cup! try again");
                chooseCup.SetActive(false);
                chooseOrder.SetActive(true);
                playerRecipe = "";
            }
            else
            {
                Debug.Log("Latte cup chosen");
                chooseCup.SetActive(false);
                chooseBean.SetActive(true);
            }
            break;
        }
    }
    public void chooseCorrectBean(Button btn)
    {
        if (btn.name == "beanType1")
        {
            playerRecipe = string.Concat(playerRecipe, '1');;
        }
        else if (btn.name == "beanType2")
        {
            playerRecipe = string.Concat(playerRecipe, '2');;
        }
        switch (selectedOrder)
        {
            case "Latte":
            if (compareRecipes(latteRecipe, playerRecipe) == false)
            {
                Debug.Log("Wrong bean! try again");
                chooseBean.SetActive(false);
                chooseOrder.SetActive(true);
                playerRecipe = "";
            }
            else
            {
                Debug.Log("Correct bean chosen");
                chooseBean.SetActive(false);
                chooseMilk.SetActive(true);
            }
            break;
        }
    }
    public void chooseCorrectMilk(Button btn)
    {
        if (btn.name == "normalMilk")
        {
            playerRecipe = string.Concat(playerRecipe, 'M');;
        }
        switch (selectedOrder)
        {
            case "Latte":
            if (compareRecipes(latteRecipe, playerRecipe) == false)
            {
                Debug.Log("Wrong milk! try again");
                chooseMilk.SetActive(false);
                chooseOrder.SetActive(true);
                playerRecipe = "";
            }
            else
            {
                Debug.Log("Good job! you completed the order and earned 20 coins!");
                chooseMilk.SetActive(false);
                chooseOrder.SetActive(true);
                playerRecipe = "";
                Destroy(this.gameObject);
            }
            break;
        }
    }
    private bool compareRecipes(string attemptedRecipe, string playerRecipe)
    {
        if (playerRecipe != "")
        {
            char[] p = playerRecipe.ToCharArray();
            char[] c = attemptedRecipe.ToCharArray();
            int length = playerRecipe.Length;
            if (p[length - 1] == c[length - 1])
            {
                Debug.Log("Returned true");
                return true;
            }
        Debug.Log("Returned false");
        return false;
        }
    Debug.Log("Returned false");
    return false;
    }
}
