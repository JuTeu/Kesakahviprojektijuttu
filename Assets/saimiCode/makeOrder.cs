using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class makeOrder : MonoBehaviour
{
    public static makeOrder instance;
    public GameObject chooseCup;
    public GameObject chooseOrder;
    public GameObject chooseBean;
    public GameObject chooseMilk;
    public GameObject chooseTopping1;
    public GameObject chooseTopping2;
    public GameObject orderList;
    private GameObject currentOrder;
    private GameObject order;
    private GameObject orderScreen;
    private int orderIndex;
    public int orderPayout;
    public int successfullOrders = 0;
    public bool isAnyOrderActive;
    orderSender orderSenderScript;
    private string latteRecipe = "L1M"; //L for latte, 1 for bean type1, FM for frothed milk
    private string espressoRecipe = "E1";
    private string catfrappeRecipe = "C2MWCCS";
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
        chooseTopping1.SetActive(false);
        chooseTopping2.SetActive(false);
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
        chooseOrder.SetActive(false);
        chooseCup.SetActive(true);
        switch(orderSenderScript.sentOrder())
        {
            case "OrderLatte":
            selectedOrder = "Latte";
            orderPayout = 20;
            break;
            
            case "OrderEspresso":
            selectedOrder = "Espresso";
            orderPayout = 15;
            break;

            case "OrderCatfrappe":
            selectedOrder = "Catfrappe";
            orderPayout = 30;
            break;
        }
    }

    // all of these functions check what ingredient is selected, compares that recipe to the recipe (string) what the user is building.
    // if at any point the recipe is wrong, it resets the users recipe (string) and goes back to choose order
    public void chooseCorrectCup(Button btn)
    {
        if (btn.name == "latteCup")
        {
            playerRecipe = string.Concat(playerRecipe, 'L');
        }
        else if (btn.name == "espressoCup")
        {
            playerRecipe = string.Concat(playerRecipe, 'E');
        }
        else if (btn.name == "catfrappeCup")
        {
            playerRecipe = string.Concat(playerRecipe, 'C');
        }
        switch (selectedOrder)
        {
            case "Latte":
            if (compareRecipes(latteRecipe, playerRecipe) == false)
            {
                failed();
            }
            else
            {
                Debug.Log("Latte cup chosen");
                chooseCup.SetActive(false);
                chooseBean.SetActive(true);
            }
            break;
            case "Espresso":
            if (compareRecipes(espressoRecipe, playerRecipe) == false)
            {
                failed();
            }
            else
            {
                Debug.Log("Espresso cup chosen");
                chooseCup.SetActive(false);
                chooseBean.SetActive(true);
            }
            break;
            case "Catfrappe":
            if (compareRecipes(catfrappeRecipe, playerRecipe) == false)
            {
                failed();
            }
            else
            {
                Debug.Log("Catfrappe cup chosen");
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
                failed();
            }
            else
            {
                Debug.Log("Correct bean chosen");
                chooseBean.SetActive(false);
                chooseMilk.SetActive(true);
            }
            break;

            case "Espresso":
            if (compareRecipes(espressoRecipe, playerRecipe) == false)
            {
                failed();
            }
            else
            {
                success(orderPayout);
            }
            break;

            case "Catfrappe":
            if (compareRecipes(catfrappeRecipe, playerRecipe) == false)
            {
                failed();
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
            playerRecipe = string.Concat(playerRecipe, 'M');
        }
        switch (selectedOrder)
        {
            case "Latte":
            if (compareRecipes(latteRecipe, playerRecipe) == false)
            {
                failed();
            }
            else
            {
                success(orderPayout);
            }
            break;

            case "Catfrappe":
            if (compareRecipes(catfrappeRecipe, playerRecipe) == false)
            {
                failed();
            }
            else
            {
                Debug.Log("Correct milk chosen");
                chooseMilk.SetActive(false);
                chooseTopping1.SetActive(true);
            }
            break;
        }
    }

    public void chooseCorrectTopping1(Button btn)
    {
        if (btn.name == "whippedCream")
        {
            playerRecipe = string.Concat(playerRecipe, "WC");
        }
        switch (selectedOrder)
        {
            case "Catfrappe":
            if (compareRecipes(catfrappeRecipe, playerRecipe) == false)
            {
                failed();
            }
            else
            {
                Debug.Log("Correct Topping chosen");
                chooseTopping1.SetActive(false);
                chooseTopping2.SetActive(true);
            }
            break;
        }
    }

    public void chooseCorrectTopping2(Button btn)
    {
        if (btn.name == "chocolateSauce")
        {
            playerRecipe = string.Concat(playerRecipe, "CS");
        }
        switch (selectedOrder)
        {
            case "Catfrappe":
            if (compareRecipes(catfrappeRecipe, playerRecipe) == false)
            {
                failed();
            }
            else
            {
                success(orderPayout);
            }
            break;
        }
    }

    public void failed() 
    {
        Debug.Log("Wrong choice! try again.");
        chooseOrder.SetActive(true);
        chooseCup.SetActive(false);
        chooseBean.SetActive(false);
        chooseMilk.SetActive(false);
        chooseTopping1.SetActive(false);
        chooseTopping2.SetActive(false);
        playerRecipe = "";
        selectedOrder = "";
        orderSenderScript.activeOrder = false;
        isAnyOrderActive = false;
        orderPayout = 0;
    }

    public void success(int orderPayout)
    {
        Debug.Log("Good job! You completed the order and earned " + orderPayout + " coins!");
        chooseOrder.SetActive(true);
        chooseCup.SetActive(false);
        chooseBean.SetActive(false);
        chooseMilk.SetActive(false);
        chooseTopping1.SetActive(false);
        chooseTopping2.SetActive(false);
        playerRecipe = "";
        Destroy(orderScreen.transform.GetChild(orderIndex).gameObject);
        isAnyOrderActive = false;
        selectedOrder = "";
        orderSenderScript.activeOrder = false;
        orderPayout = 0;
        successfullOrders++;
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
