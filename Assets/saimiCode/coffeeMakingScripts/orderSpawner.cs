using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderSpawner : MonoBehaviour
{
    public static orderSpawner instance;
    public GameObject[] orders;
    public Transform parent;
    public static int orderCounter;
    private bool isShopping;
    private float moneyMadeDaily;
    private float _interval;
    private float _time;




    // TODO: Day tracker. day ends ever 12 orders, so check when 12 orders have filled, give player option to go shopping
    // add "skip shopping" -> moves to next day and another 12 orders come with time in between
    // add "go shopping", fill cart etc, and "done with shopping" -> move to next day

    // TODO: order randomization. Check what drinks are unlocked, what upgrades are unlocked and how
    // many drinks can be ordered per order

    private void Start()
    {
        instance = this;
        orderCounter = 0;
        moneyMadeDaily = 0;
        _time = 0f;
        _interval = 0.1f;
    }
    private void Update()
    {
        _time = Time.deltaTime;
        if (_interval == 0.1f)
        {
            _interval = Random.Range(25, 45);
        }
        if (_time >= _interval)
        {
            _time -= _interval;
            _interval = 0.1f;
            instantiateNewOrder();
        }
    }
    public void dayTracker()
    {
        if (orderCounter == 12)
        {
            _interval = 9999999999999f;
            //poput window to show how much money made that day, how many orders server (if you ended day early, its less than 12 etc)
            //maybe count some other fun stats like, how many times you fucked up an order, or discarded a drink
            
            //poput windows to go shopping or go to next day
        }
    }


    private void instantiateNewOrder()
    {
        //pick random from orders[] and thats a customers order
        int randomIndex = Random.Range(0, orders.Length);
        Instantiate(orders[randomIndex], parent);
        orderCounter++;
    }
}
