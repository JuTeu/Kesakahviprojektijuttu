using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRobot : MonoBehaviour
{
    [SerializeField] Animator mainAnim, bodyAnim, handsAnim;
    [SerializeField] Vector2 patrol1, patrol2;
    Transform playerTransform;
    Vector2 patrolTarget;
    bool playerIsNear = false, isAlive = true;

    void Start()
    {
        patrolTarget = patrol1;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIsNear = true;
            playerTransform = collision.gameObject.GetComponent<Transform>();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIsNear = false;
        }
    }

    void Update()
    {
        if (!isAlive) return;
        if (playerIsNear)
        {
            if (bodyAnim.GetCurrentAnimatorStateInfo(0).IsName("FacingLeft") && playerTransform.position.x > transform.position.x) bodyAnim.Play("TurnToRight");
            else if (bodyAnim.GetCurrentAnimatorStateInfo(0).IsName("FacingRight") && playerTransform.position.x < transform.position.x) bodyAnim.Play("TurnToLeft");
        }
        else
        {
            if (bodyAnim.GetCurrentAnimatorStateInfo(0).IsName("FacingLeft") && patrolTarget.x > transform.position.x) bodyAnim.Play("TurnToRight");
            else if (bodyAnim.GetCurrentAnimatorStateInfo(0).IsName("FacingRight") && patrolTarget.x < transform.position.x) bodyAnim.Play("TurnToLeft");
        }

        if (!handsAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (Vector2.Distance(transform.position, patrolTarget) < 0.1f)
            patrolTarget = patrolTarget == patrol1 ? patrol2 : patrol1;
            transform.position = Vector2.MoveTowards(
                                transform.position, patrolTarget, Time.deltaTime);
        }

        if (playerIsNear)
        {
            handsAnim.Play("Attack");
        }
    }

    public void Die()
    {
        isAlive = false;
        handsAnim.Play("Die");
        mainAnim.Play("Die");
        Debug.Log("AU");
    }
}
