using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPit : MonoBehaviour
{

    public GameObject player;
    public Transform respawnPoint;


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //            player.transform.position = respawnPoint.position;
            other.gameObject.transform.position = respawnPoint.position;

            // lis‰t‰‰n ‰‰ni
            float delay = 0;
            AudioSource audio = GetComponent<AudioSource>();

            // jos ‰‰ni lˆytyy, se lis‰t‰‰n
            if (audio != null)
            {

                // pistet‰‰n delay, jotta audioklippi soi
                delay = audio.clip.length;
                audio.Play();

            }

        }
    }
}




