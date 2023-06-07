using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().Damage(2, 20, transform.position, 0, 1);
        }
    }
}
