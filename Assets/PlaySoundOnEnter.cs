using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaySoundOnEnter : MonoBehaviour
{

    AudioSource source;
    Collider2D soundTrigger;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();

    }

    void OnTriggerEnter2D(Collider2D collider)

    {
    //    source.Play();

    }
    void OnTriggerExit2D(Collider2D collider)

    {
        source.Play();
    }
}