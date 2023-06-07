using UnityEngine;
public class enemyPatrol : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2f;

    private float targetPosition;
    private int direction = 1; // Initial direction: 1 for moving forward, -1 for moving backward

    private void Start()
    {
        transform.position = startPoint.position;
        targetPosition = endPoint.position.x;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime * direction;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPosition, transform.position.y), step);

        if (transform.position.x == targetPosition)
        {
            if (targetPosition == endPoint.position.x)
            {
                targetPosition = startPoint.position.x;
            }
            else
            {
                targetPosition = endPoint.position.x;
            }
            direction *= -1;
        }
    }
}
