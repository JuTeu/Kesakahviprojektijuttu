using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTest : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] PlayerMover playerMover;
    public bool animate = true;
    bool playerIsNear = false, alreadyInteracted = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.tag == "Player" && animate && !GameManager.playerIsReturningFromPortal)
        {
            anim.Play("PortalOpen");
        }*/

        playerIsNear = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        playerIsNear = false;
        
        /*if(collision.tag == "Player" && animate && !GameManager.playerIsReturningFromPortal)
        {
            anim.Play("PortalClose");
        }
        
        else if (collision.tag == "Player" && GameManager.playerIsReturningFromPortal)
        {
            //GameManager.playerIsReturningFromPortal = false;
            animate = true;
        }*/

        
    }

    public void PlayAnim(int id)
    {
        if (id == 0)
        {
            anim.Play("PortalOpen");
        }
        else if (id == 1)
        {
            
        }
    }

    void Update()
    {
        if (!playerIsNear) return;
        if(playerMover.interacting && !alreadyInteracted)
        {
            alreadyInteracted = true;
            GameManager.OpenLevel("LevelSelectMenu");
            GameManager.playerIsInControl = false;
        }
        else if (!playerMover.interacting)
        {
            alreadyInteracted = false;
        }
    }
}
