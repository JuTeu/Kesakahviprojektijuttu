using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPPickup : MonoBehaviour
{
    [SerializeField] int magicPowerAmount = 4;
    [SerializeField] ParticleSystem[] particles;
    [SerializeField] Color playerFlashColor;
    bool collected = false;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.position = Vector2.MoveTowards(transform.position,
                collision.gameObject.transform.position, 10 * Time.deltaTime);
            
            if (!collected &&
                transform.position == collision.gameObject.transform.position)
                StartCoroutine(Collect(collision.gameObject));
        }
    }

    IEnumerator Collect(GameObject player)
    {
        collected = true;
        foreach (ParticleSystem particle in particles)
        {
            particle.Stop();
        }
        player.GetComponent<PlayerMagic>().GainMagicPower(magicPowerAmount);
        float flash = 0;
        while (flash < 1)
        {
            flash += Time.deltaTime;
            if (flash > 1) flash = 1;
            player.transform.GetChild(0).GetComponent<SpriteRenderer>().color
            = Color.Lerp(playerFlashColor, Color.white, flash);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
