using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelExit : MonoBehaviour
{
    bool portalClosingFinished = false;
    PlayerHealth playerHealth;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        portalClosingFinished = GameManager.levelExitPortalFinishedClosing;

        if (playerHealth.GetHealth() <= 0 || player.transform.position.y < -10)
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
        GameManager.CloseLevel("PlatformerTestLevel");
        GameManager.EnableCafeCollisions(true);
        GameManager.SetGameMode(0);
        GameManager.playerIsInControl = true;
    }
}
