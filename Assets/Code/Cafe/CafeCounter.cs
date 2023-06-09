using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeCounter : MonoBehaviour
{
    [SerializeField] SpriteRenderer outline;
    [SerializeField] PlayerMover playerMover;
    Color outlineColor;
    bool playerIsInside = false;
    // Start is called before the first frame update
    void Start()
    {
        outlineColor = outline.color;
        outline.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerIsInside) return;
        if(playerMover.interacting && !alreadyInteracted)
        {
            alreadyInteracted = true;
            GameManager.OpenLevel("saimiTestScene");
            GameManager.playerIsInControl = false;
        }
        else if (!playerMover.interacting)
        {
            alreadyInteracted = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            outline.color = outlineColor;
            playerIsInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            outline.color = new Color(0, 0, 0, 0);
            playerIsInside = false;
        }
    }
    bool alreadyInteracted = false;
    void OnTriggerStay2D(Collider2D collision)
    {
        

    }
}
