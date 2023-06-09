using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    //	[SerializeField]
    //	private Transform target;

    // [SerializeField] private float smoothTime = 0.3f;

    //[SerializeField]
    //private Vector3 offset;

    [SerializeField] private float xPos;
    [SerializeField] private float cameraY;
    [SerializeField] private float CameraSpeed;
    [SerializeField, Range(-5, 5)] private float offSet;
    //private Vector3 velocity = Vector3.zero;
    public GameObject player;

    void Update()
    {
        // m��ritet��n kameran sijainti
        //Vector3 targetPosition = target.TransformPoint(offset);

        // liikutetaan kameraa pehme�sti
        //
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        // transform.position = Vector3.SmoothDamp(transform.position,transform.position.y, transform.position.z, smoothTime);

        // f perään, niin toimii float
        // useampi y arvo = useampi steppi kameralle
        //a

        cameraY = player.transform.position.y + offSet;
        cameraY = Mathf.Clamp(cameraY, -6f, 13f);

            //Vector3 newPosition = new Vector3(player.transform.position.x + xPos, y, transform.position.z);

            //transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime*CameraSpeed);




            // player.transform.position.y jos halutaan kameran seuraavan my�s pysty liikett�
            //transform.position = new Vector3(player.transform.position.x + xPos, transform.position.y, transform.position.z);

            // *******************alla oleva toimii normaalisti vaan horizontaalina*******************
            // transform.position = new Vector3(player.transform.position.x + xPos, transform.position.y, transform.position.z);
        

        Vector3 newPosition = new Vector3(player.transform.position.x + xPos, cameraY, transform.position.z);

        transform.position = Vector3.Lerp(transform.position,  newPosition, Time.deltaTime * CameraSpeed);

        //        public void SetTarget(GameObject newTarget)
        //      {
        // asetetaan uusi main kameran kohta transformilla
        //        this.target = newTarget.transform;
        //  }
        //  

        // Lerp(transform.position) alkuperäinen arvo, Time.time kasvattaa tasaisesti 


    }
}