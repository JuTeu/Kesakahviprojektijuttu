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
    public Button latteCup;
    public Button normalCup;
    public Button beanType1;
    public Button beanType2;
    public Button normalMilk;
    /*private string chosenCup;
    private string chosenBean;
    private string chosenMilk;*/

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
        StartCoroutine(latteMaking());
    }

    IEnumerator latteMaking()
    {
        var waitForButtons = new WaitForUIButtons(latteCup, normalCup, beanType1, beanType2, normalMilk);
        yield return waitForButtons.Reset();
        chooseOrder.SetActive(false);
        chooseCup.SetActive(true);
        if (waitForButtons.PressedButton != latteCup)
        {
            Debug.Log("Wrong cup! try again");
            chooseCup.SetActive(false);
            chooseOrder.SetActive(true);
        }
        else
        {
            Debug.Log("Latte cup chose");
            chooseCup.SetActive(false);
            chooseBean.SetActive(true);
        }
        if (waitForButtons.PressedButton != beanType1)
        {
            Debug.Log("Wrong bean! try again");
            chooseBean.SetActive(false);
            chooseOrder.SetActive(true);
        }
        else
        {
            Debug.Log("Correct bean chosen");
            chooseBean.SetActive(false);
            chooseMilk.SetActive(true);
        }
        if (waitForButtons.PressedButton != normalMilk)
        {
            Debug.Log("Wrong milk! try again");
            chooseMilk.SetActive(false);
            chooseOrder.SetActive(true);
        }
        else
        {
            Debug.Log("Good job! you completed the order and earned 20 coins!");
            chooseMilk.SetActive(false);
            chooseOrder.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    /*public void chooseCorrectCup(Button btn)
    {
        if (btn.name == "latteCup")
        {
            chosenCup = "latteCup";
        }
        else if (btn.name =="normalCup")
        {
            chosenCup = "normalCup";
        }
    }
    public void chooseCorrectBean(Button btn)
    {
        if (btn.name == "beanType1")
        {
            chosenBean = "beanType1";
        }
        else if (btn.name == "beanType2")
        {
            chosenBean = "beanType2";
        }
    }

    public void chooseCorrectMilk(Button btn)
    {
        if (btn.name == "normalMilk")
        {
            chosenMilk = "normalMilk";
        }
    }*/
}
