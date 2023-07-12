using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    bool portalClosingFinished = false;

    Health playerHealth;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<Health>();

        Sprite newSprite = GameManager.GetCollectibleSprite(GameManager.currentLevel);
        if (newSprite != null)
        {
            gameObject.transform.Find("CollectibleSprite").GetComponent<SpriteRenderer>().sprite = newSprite;
        }
        else
        {
            Debug.LogError($"Kenttään nro. {GameManager.currentLevel} ei ole määritetty kentän lopun spritea, määrittele se GameManagerin LevelManager komponentissa! (määriteltävän indeksi: {GameManager.currentLevel * 4})");
        }
    }

    // Update is called once per frame
    void Update()
    {
        portalClosingFinished = GameManager.levelExitPortalFinishedClosing;

        if (playerHealth.GetHealth() <= 0 || player.transform.position.y < -200)
        {
            player.transform.position = Vector2.zero;
            playerHealth.Heal(10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(ExitLevel());
        }
    }

   IEnumerator ExitLevel()
    {
        GameManager.levels[GameManager.currentLevel] |= 0b_10;
        GameManager.playerIsInControl = false;
        GameManager.playerIsReturningFromPortal = true;
        GameManager.ActivateCafe(true);
        Rigidbody2D playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        playerRb.gravityScale = 0;
        playerRb.velocity = Vector2.zero;
        GameObject.FindWithTag("Portal").GetComponent<Animator>().Play("PortalExitLevel");
        yield return new WaitUntil(() => portalClosingFinished);
        GameObject camera = Camera.main.gameObject;
        camera.transform.SetParent(playerRb.transform);
        playerRb.position = Vector2.zero; // Pelaajan sijainti takaisin alkuun
        yield return new WaitForSecondsRealtime(0.1f); // Lapset ei tule muuten mukana
        camera.transform.SetParent(null);
        GameManager.TurnCafeIntoAChildOfThePlayer(false);
        GameManager.CloseLevel(GameManager.GetLevelName(GameManager.currentLevel));
        GameManager.EnableCafeCollisions(true);
        GameManager.SetGameMode(0);
        GameManager.playerIsInControl = true;
    }
}
