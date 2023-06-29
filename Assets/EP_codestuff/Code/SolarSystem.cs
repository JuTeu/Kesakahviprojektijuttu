using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public Transform sun; //sun as a center
    public float speed;
    public Vector3 axis;


    // Start is called before the first frame update
    void Start()
    {
        //axis = new Vector3(0, Random.Range(0f, 1f), Random.Range(0f, 1f));
        //axis = new Vector3(0, Random.Range(0f, 1f), 0);
        axis = new Vector3(0, 0, Random.Range(0f, 0.5f));

        speed = Random.Range(1f, 3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(sun.position, axis, speed * Time.deltaTime);
    }
}
