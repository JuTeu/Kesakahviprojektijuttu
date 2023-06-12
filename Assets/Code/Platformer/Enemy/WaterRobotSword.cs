using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRobotSword : MonoBehaviour
{
    public bool isSwinging = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().Damage(isSwinging ? 4 : 2, 20, transform.position, isSwinging ? 1 : 0, 1f);
        }
    }
}
