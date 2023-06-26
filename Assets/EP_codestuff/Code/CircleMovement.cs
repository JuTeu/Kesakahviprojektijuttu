using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, 0f, 10f * Time.deltaTime * speed);
    }
}
