using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    public bool oneTimeUse = false;
    [SerializeField] UnityEvent pullLeft, pullRight;
    [SerializeField] Animator anim;
    PlayerMover mover;
    bool currentDirection = false, alreadyPulled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (mover == null && collision.tag == "Player") mover 
            = collision.gameObject.GetComponent<PlayerMover>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Player" || mover == null ||
            oneTimeUse && currentDirection) return;

        if (!alreadyPulled && mover.GetMoveInput() == Vector2.up)
        {
            alreadyPulled = true;
            Pull();
        }
        else if (alreadyPulled && mover.GetMoveInput() != Vector2.up)
        {
            alreadyPulled = false;
        }

    }

    void Pull()
    {
        if (currentDirection)
        {
            currentDirection = false;
            anim.Play("PullToLeft");
            pullLeft.Invoke();
        }
        else
        {
            currentDirection = true;
            anim.Play("PullToRight");
            pullRight.Invoke();
        }
    }
}
