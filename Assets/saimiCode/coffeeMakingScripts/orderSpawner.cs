using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class orderSpawner : MonoBehaviour
{
    public GameObject[] orders;
    public Transform parent;


    //this function picks a random drink, spawns the order to the order list, and adds 1 to order counter.
    public void instantiateNewOrder()
    {
        //pick random from orders[] and thats a customers order
        int randomIndex = Random.Range(0, orders.Length);
        Instantiate(orders[randomIndex], parent);
    }
}
