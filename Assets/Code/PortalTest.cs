using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTest : MonoBehaviour
{
    [SerializeField] Animator anim;
    public bool animate = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && animate)
        {
            anim.Play("PortalOpen");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player" && animate)
        {
            anim.Play("PortalClose");
        }
    }
}
