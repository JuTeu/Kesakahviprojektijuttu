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
    Vector2 target;
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        cam = Camera.main.transform;
        target = mainView;
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
        if (playerIsInStorageRoom != playerWasInStorageRoom)
        {
            playerWasInStorageRoom = playerIsInStorageRoom;
            room1.enabled = !playerIsInStorageRoom;
            room2.enabled = playerIsInStorageRoom;
            doorFrameSprite.sortingOrder = playerIsInStorageRoom ? 12 : 10;
            target = playerIsInStorageRoom ? storageView : mainView;
        }
    }

    void CameraMovement()
    {
        cam.position = new Vector3(
                Mathf.MoveTowards(cam.position.x, target.x, 4 * Time.deltaTime),
                Mathf.MoveTowards(cam.position.y, target.y, 4 * Time.deltaTime), -10);
    }
}
