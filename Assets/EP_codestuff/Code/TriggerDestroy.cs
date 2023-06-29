using UnityEngine;

public class TriggerDestroy : MonoBehaviour
{

    public GameObject breakableWall;
    public float respawnTime = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(breakableWall);
            Invoke("RespawnWall", respawnTime);
        }
    }
}