using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2f;
    public float targetThreshold = 0.1f; // Threshold for considering the enemy to have reached the target position

    private Vector3 targetPosition;
    private int direction = 1; // Initial direction: 1 for moving forward, -1 for moving backward
    private bool isAtEnd = false; // Flag to track if the enemy is at the end point

    private void Start()
    {
        transform.position = startPoint.position;
        targetPosition = endPoint.position;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime * direction;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (Vector3.Distance(transform.position, targetPosition) <= targetThreshold)
        {
            if (isAtEnd)
            {
                targetPosition = startPoint.position;
                isAtEnd = false;
            }
            else
            {
                targetPosition = endPoint.position;
                isAtEnd = true;
            }
            direction *= -1;
        }
    }
}
