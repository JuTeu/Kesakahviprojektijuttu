using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 10;

    [Range(1, 10)]
    [SerializeField] private float lifeTime = 3f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // destroyes the gameobject after certain time has passed
        Destroy(gameObject, lifeTime);

    }

    // making the bullet go straigth all the time.
    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }

}
