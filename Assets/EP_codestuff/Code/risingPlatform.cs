using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class risingPlatform : MonoBehaviour
{
    public Rigidbody2D rb;
    public float launchForce;
    public GameObject elevator;
    public Transform respawnPoint;

    public Transform elevatorStartPoint;


    // addforce
    public void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.up * launchForce;
        }
        if (collision.gameObject.CompareTag("elevatorTrigger"))
          
        {
            gameObject.transform.position = respawnPoint.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

}

