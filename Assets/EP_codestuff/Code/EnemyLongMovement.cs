using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLongMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check the patrol destination of the enemy
        if (patrolDestination == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
            {
                patrolDestination = 1;

            }

        }
        if (patrolDestination == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[2].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[2].position) < .2f)
            {
                patrolDestination = 3;

            }

        }
        if (patrolDestination == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[3].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[3].position) < .2f)
            {
                patrolDestination = 4;

            }

        }
        if (patrolDestination == 4)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[4].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[4].position) < .2f)
            {
                patrolDestination = 5;

            }

        }
        if (patrolDestination == 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[5].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[5].position) < .2f)
            {
                patrolDestination = 6;

            }

        }
        if (patrolDestination == 6)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[6].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[6].position) < .2f)
            {
                patrolDestination = 0;
            }
        }
    } 
}
  

