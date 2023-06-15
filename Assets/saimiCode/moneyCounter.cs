using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;
using UnityEngine.SceneManagement;
public class moneyCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    private int moneyToBeAdded = 0;
    private int allMoney;
    private int successfullOrderTracker = 0;

    // TODO:
    //alota update vasta kun tilausten teko näkymä on avattu.
    //Tää olisi mahdollista (ehkä) gamemanagerista kun hakee levelmanagerin ja levelnamen, mutta
    //tätä ei saanut sen protection levelin takia (juho, mitä tehdä? ensun scriptei ala ite sorkkii etten riko mitää:D)

    //LevelManager levelManager;

    /*void Start()
    {
        levelManager = GetComponent<LevelManager>();
    }*/
    private void FixedUpdate()
    {
        //if (GameManager.Instance.levelManager.OpenLevel == "saimiTestScene")
        //{
            addeableMoney();
            updateMoney();
            addeableMoney();
        //}
    }
    private void addeableMoney()
    {
        if (makeOrder.isAnyOrderActive)
        {
            moneyToBeAdded = makeOrder.orderPayout;
        }
    }

    private void updateMoney()
    {
        if (makeOrder.successfullOrders > successfullOrderTracker)
        {
            addMoney(moneyToBeAdded);
            successfullOrderTracker = makeOrder.successfullOrders;
        }
    }

    private void deleteAddeableMoney()
    {
        if (!makeOrder.isAnyOrderActive)
        {
            moneyToBeAdded = 0;
        }
    }

    private void addMoney(int value)
    {
        allMoney += value;
        moneyText.text = "coins: " + allMoney;
    }
}
