using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFireTrigger : MonoBehaviour
{

    public GameObject risingFire;
    public Transform respawnPoint;
    public Rigidbody2D rb;


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            risingFire.transform.position = respawnPoint.position;
            rb.velocity = Vector2.zero;

        }
    }
}