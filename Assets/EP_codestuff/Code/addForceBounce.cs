using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addForceBounce : MonoBehaviour
{
    Rigidbody2D rb;
    public float m_Thrust = 20f;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            rb.AddForce(transform.up * m_Thrust);
        }
    }
}