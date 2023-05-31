using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeDoorTrigger : MonoBehaviour
{
    bool playerIsInStorageRoom = false, playerWasInStorageRoom = false;
    float room1Opacity = 1;
    Transform cam;
    [SerializeField] Collider2D room1, room2;
    [SerializeField] SpriteRenderer room1Sprite, doorFrameSprite;
    [SerializeField] Vector2 mainView, storageView;
    Vector2 targetPos, currentPos;
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        cam = Camera.main.transform;
        targetPos = mainView;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerIsInStorageRoom = collision.gameObject.transform.position.y > 0.01f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
        
        if (playerIsInStorageRoom && room1Opacity > 0)
        {
            room1Opacity -= 2 * Time.deltaTime;
            room1Sprite.color = new Color(1, 1, 1, room1Opacity);
        }
        else if (!playerIsInStorageRoom && room1Opacity < 1)
        {
            room1Opacity += 2 * Time.deltaTime;
            room1Sprite.color = new Color(1, 1, 1, room1Opacity);
        }

        // Tapahtuu kerran kun pelaaja poistuu tai menee huoneeseen
        if (playerIsInStorageRoom != playerWasInStorageRoom)
        {
            playerWasInStorageRoom = playerIsInStorageRoom;
            room1.enabled = !playerIsInStorageRoom;
            room2.enabled = playerIsInStorageRoom;
            doorFrameSprite.sortingOrder = playerIsInStorageRoom ? 12 : 10;
            targetPos = playerIsInStorageRoom ? storageView : mainView;
        }
    }

    void CameraMovement()
    {
        currentPos = cam.position;
        currentPos = Vector2.MoveTowards(currentPos, targetPos, 5 * Time.deltaTime);
        cam.position = new Vector3(currentPos.x, currentPos.y, -10);
    }
}
