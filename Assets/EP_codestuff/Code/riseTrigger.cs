using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class riseTrigger : MonoBehaviour
{
    public Rigidbody2D rb;
    public float launchForce;
    public GameObject trigger;

    public GameObject elevator;
    public GameObject player;
    public Transform playerStartPoint;
    public Transform fireRespawnPoint;
    // Update is called once per frame

    public void onCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.up * launchForce;
        }

    

    }
}
