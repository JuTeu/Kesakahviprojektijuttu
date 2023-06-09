using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class orderSender : MonoBehaviour
{
    public bool activeOrder = false;
    private string orderName;
    private int index;

    public void orderSelected()
    {
        activeOrder = true;
    }
    public void orderNameSetter()
    {
        orderName = EventSystem.current.currentSelectedGameObject.name;
    }
    public void orderIndex()
    {
        index = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();
    }
    public int orderOrder()
    {
        return index; 
    }
    public string sentOrder()
    {
        return orderName;
    }
    public bool isOrderActive()
    {
        return activeOrder;
    }
}
