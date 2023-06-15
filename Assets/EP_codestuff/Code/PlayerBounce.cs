using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounce : MonoBehaviour
{
    public Rigidbody2D rb;
    public float launchForce;
    public GameObject elevator;
    public Transform respawnPoint;


    // addforce
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.up * launchForce;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("elevatorTrigger"))
        {
            elevator.transform.position = respawnPoint.position;
        }
    }
}
