using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderSpawner : MonoBehaviour
{
    public GameObject order;
    public Transform parent;
    public void instantiateNewOrder()
    {
        Instantiate(order, parent);
    }
}
