using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    bool fly = false;
    bool exploded = false;
    Health health;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] ParticleSystem fireBase, fireGlow;
    [SerializeField] GameObject ball, fireExplosion;
    public bool isPlayerAligned = true;
    
    void Start()
    {

    }

    public void Shoot(float delay, float rotation)
    {
        rb.rotation = rotation;
        StartCoroutine(IEShoot(delay));
    }

    IEnumerator IEShoot(float delay)
    {
        yield return new WaitForSeconds(delay);
        fly = true;

        yield return new WaitForSeconds(2);
        StartCoroutine(Explode());
    }

    void Update()
    {
        if (fly && !exploded) rb.AddForce(transform.right * 10);
        else if (exploded) rb.velocity = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            if (health.GetIsPlayerAligned() != isPlayerAligned)
            {
                health.Damage(5, 20, transform.position, 1, 0.1f);
                StartCoroutine(Explode());
            }
        }
        else if (collision.gameObject.layer == 6 && !exploded) // Layer 6 on maa, eli tuhoa kun osuu maahan
        {
            StartCoroutine(Explode());
        }
    }
    IEnumerator Explode()
    {
        exploded = true;
        fireBase.Stop();
        fireGlow.Stop();
        ball.SetActive(false);
        fireExplosion.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
