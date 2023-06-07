using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sprite;
    int health = 10;
    float iFrames = 0;
    public bool invulnerableToContactDamage = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Vahinko tyypit: 0 = kontaktivahinko, 1 = ???, ...
    public void Damage(int damage, float knockbackForce, Vector2 knockbackSourceLocation, int type, float invinsibilityFrames)
    {
        if (iFrames > 0) return;
        else if (type == 0 && invulnerableToContactDamage) return;

        iFrames = invinsibilityFrames;
        Vector2 knockbackDirection = (Vector2) transform.position - knockbackSourceLocation;
        Vector2 knockbackForceVector = knockbackDirection.normalized * knockbackForce;
        knockbackForceVector = new Vector2(knockbackForceVector.x, knockbackForceVector.y * 3);
        Debug.Log(knockbackForceVector);
        health -= damage;
        if (health > 0) rb.AddForce(knockbackForceVector, ForceMode2D.Impulse);
        Debug.Log("Elämä: " + health);
    }

    // Update is called once per frame
    void Update()
    {
        if (iFrames > 0f) { 
            iFrames -= Time.deltaTime;
            sprite.color = new Color(1f, 1f, 1f, Mathf.Sin(32 * iFrames) / 2 + 0.5f);
            if (iFrames < 0.1f) sprite.color = Color.white;
        }
    }


}
