using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class FallingPlatform : MonoBehaviour
    {
        private float fallDelay = 1f;
        // private float destroyDelay = 2f;
        Vector2 initialPosition;
        bool platformMovingBack;

        [SerializeField] private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            initialPosition = transform.position;

        }

        private void Update()
        {
            if (platformMovingBack)
                transform.position = Vector2.MoveTowards(transform.position, initialPosition, 20f * Time.deltaTime);
            if (transform.position.y == initialPosition.y)
                platformMovingBack = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && !platformMovingBack) 
            {
                Invoke("DropPlatform", 1f);
            }
        }

        void DropPlatform()
        {
            rb.isKinematic = false;
            // delay platformin nostolle
            Invoke("GetPlatformBack", 2f);
        }
 
        
        void GetPlatformBack()
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            platformMovingBack = true;
        }
    } 

