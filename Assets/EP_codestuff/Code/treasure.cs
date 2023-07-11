using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    bool reward1 = false;
    bool reward2 = false;
    bool reward3 = false;

    bool reward4 = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            reward1 = true;
        }
        if (collision.CompareTag("Player"))
        {
            reward2 = true;
        }
        if (collision.CompareTag("Player"))
        {
            reward3 = true;
        }
        if (collision.CompareTag("Player"))
        {
            reward4 = true;
        }
        Debug.Log("palkinko1: " +reward1);
        Debug.Log("palkinto2; " +reward2);
        Debug.Log("palkinto3; " +reward3);
        Debug.Log("palkinto3; " +reward4);
    }
}