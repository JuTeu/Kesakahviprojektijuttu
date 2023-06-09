using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class makeOrder : MonoBehaviour
{
    public GameObject chooseCup;
    public GameObject chooseOrder;
    public GameObject chooseBean;
    public GameObject chooseMilk;
    public GameObject orderList;
    private GameObject currentOrder;
    private GameObject order;
    private GameObject orderScreen;
    private int orderIndex;
    private bool isAnyOrderActive;
    orderSender orderSenderScript;
    private string latteRecipe = "L1M"; //L for latte, 1 for bean type1, FM for frothed milk
    private string playerRecipe = "";
    private string selectedOrder = "";


    //TODO: 1: Add a back button to stop making an order and go back
    //2: add counter for money
    void Awake()
    {
        order = GameObject.Find("onderSenderScriptHolder");
        orderSenderScript = order.GetComponent<orderSender>();
        isAnyOrderActive = false;
        orderScreen = GameObject.Find("gridContent");
        orderSenderScript.activeOrder = false;
    }
    private void Start() //hide ingredients bcs no order is selected yet
    {
        chooseOrder.SetActive(true);
        chooseCup.SetActive(false);
        chooseBean.SetActive(false);
        chooseMilk.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (orderSenderScript.isOrderActive() && selectedOrder == "" && !isAnyOrderActive)
        {
            acceptOrder();
            isAnyOrderActive = true;
            Debug.Log("order accepted");
            orderIndex = orderSenderScript.orderOrder();
        }
    }
    public void acceptOrder() //Adding more orders here later with more drinks. Maybe switch case is better used later.
    {
        if (orderSenderScript.sentOrder() == "OrderLatte")
        {
            makeLatte();
        }
    }

    private void makeLatte() // defines what order is being made
    {
        chooseOrder.SetActive(false);
        chooseCup.SetActive(true);
        selectedOrder = "Latte";
    }


    // all of these functions check what ingredient is selected, compares that recipe to the recipe (string) what the user is building.
    // if at any point the recipe is wrong, it resets the users recipe (string) and goes back to choose order
    public void chooseCorrectCup(Button btn)
    {
        if (btn.name == "latteCup")
        {
            playerRecipe = string.Concat(playerRecipe, 'L');
        }
        else if (btn.name == "normalCup")
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
                selectedOrder = "";
                orderSenderScript.activeOrder = false;
                isAnyOrderActive = false;
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
                selectedOrder = "";
                orderSenderScript.activeOrder = false;
                isAnyOrderActive = false;
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
                selectedOrder = "";
                orderSenderScript.activeOrder = false;
                isAnyOrderActive = false;
            }
            else
            {
                Debug.Log("Good job! you completed the order and earned 20 coins!");
                chooseMilk.SetActive(false);
                chooseOrder.SetActive(true);
                playerRecipe = "";
                Destroy(orderScreen.transform.GetChild(orderIndex).gameObject);
                isAnyOrderActive = false;
                selectedOrder = "";
                orderSenderScript.activeOrder = false;
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
