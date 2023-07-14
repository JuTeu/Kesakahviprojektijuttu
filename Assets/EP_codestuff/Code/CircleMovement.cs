using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, 0f, -5f * Time.deltaTime * speed);
    }
}
