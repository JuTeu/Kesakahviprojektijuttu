using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class orderTimer : MonoBehaviour
{

    public static orderTimer instance;
    private orderSpawner orderSpawnerScript;
    public GameObject poputWindow;
    public static int orderCounter;
    private bool isShopping;
    private int pendingOrders;
    public static float moneyMadeDaily;
    private float _interval;
    private float _time;

    
    // TODO: Day tracker. day ends ever 12 orders, so check when 12 orders have filled, give player option to go shopping
    // add "skip shopping" -> moves to next day and another 12 orders come with time in between
    // add "go shopping", fill cart etc, and "done with shopping" -> move to next day

    // TODO: order randomization. Check what drinks are unlocked, what upgrades are unlocked and how
    // many drinks can be ordered per order

    // Since the coffee making view is its own scene, it makes this trickier.
    // Save the amount of "generated" orders in the background, and when the coffee making window is displayed, spawn them instantly
    // all the data of how many orders are active, and done, HAVE to be in this script, since this scene wont be
    // unloaded at any time (saving real-time data can be done too, its harder)

    private void Start()
    {
        instance = this;
        orderCounter = 0;
        moneyMadeDaily = 0;
        _time = 0f;
        _interval = 0.1f;
        pendingOrders = 0;
        poputWindow.SetActive(false);
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
            pendingOrders++;
        }
    }

    public void dayTracker()
    {
        if (orderCounter == 12)
        {
            _interval = 9999999999999f;
            poputWindow.SetActive(true);
            
            //poput window to show how much money made that day, how many orders server (if you ended day early, its less than 12 etc)
            //maybe count some other fun stats like, how many times you fucked up an order, or discarded a drink
            
            //poput windows to go shopping or go to next day
            
        }
    }
    public void spawnOrders()
    {
        string sceneName = "saimiTestScene";
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == sceneName)
            {
                
            }
        }
    }
}



