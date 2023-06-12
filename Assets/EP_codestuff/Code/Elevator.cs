using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform player;
    public Transform elevatorSwitch;
    public Transform downPos;
    public Transform upperPos;
    public SpriteRenderer elevator;

    public float speed;
    private bool isElevatorDown;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsMouseOverSwitch())
        {
            ToggleElevatorDirection();
        }

        MoveElevator();
        DisplayColor();
    }

    bool IsMouseOverSwitch()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        return Vector3.Distance(mousePosition, elevatorSwitch.position) < 0.5f;
    }

    void ToggleElevatorDirection()
    {
        isElevatorDown = !isElevatorDown;
    }

    void MoveElevator()
    {
        if (isElevatorDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, downPos.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speed * Time.deltaTime);
        }
    }

    void DisplayColor()
    {
        if (transform.position.y <= downPos.position.y || transform.position.y >= upperPos.position.y)
        {
            elevator.color = Color.green;
        }
        else
        {
            elevator.color = Color.red;
        }
    }
}
