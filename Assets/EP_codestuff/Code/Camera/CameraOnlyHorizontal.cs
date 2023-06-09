using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnlyHorizontal : MonoBehaviour
{
    //	[SerializeField]
    //	private Transform target;

    // [SerializeField] private float smoothTime = 0.3f;

    //[SerializeField]
    //private Vector3 offset;

        [SerializeField] private float yPos;
        [SerializeField] private float xPos;
        //[SerializeField] private double y; 
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

       /// if (player.transform.y > 0.80)
        //{
         //   y = 3.50;
           // transform.position = new Vector3(player.transform.position.x + xPos, transform.position.y, transform.position.z);

        //}
        //else
          //  {
            //y = -0.5;
            transform.position = new Vector3(transform.position.x + xPos, player.transform.position.y +yPos, transform.position.z);

      


        // player.transform.position.y jos halutaan kameran seuraavan my�s pysty liikett�
        //transform.position = new Vector3(player.transform.position.x + xPos, transform.position.y, transform.position.z);
        
        // *******************alla oleva toimii normaalisti vaan horizontaalina*******************
            // transform.position = new Vector3(player.transform.position.x + xPos, transform.position.y, transform.position.z);
        }
        /*
                public void SetTarget(GameObject newTarget)
                {
                    // asetetaan uusi main kameran kohta transformilla
                    this.target = newTarget.transform;
                }
        */
    }
