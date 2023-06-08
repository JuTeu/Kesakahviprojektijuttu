using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] bool isPlayerAligned = false;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] int maxHealth = 10;
    int health = 10;
    float iFrames = 0;
    public float knockbackResistance = 0;
    public bool invulnerableToContactDamage = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (sprite == null) sprite = GetComponent<SpriteRenderer>();
    }

    public bool GetIsPlayerAligned() {return isPlayerAligned;}
    public int GetHealth() {return health;}

    public void Heal(int healthAmount)
    {
        health += healthAmount;
        if (health > maxHealth) health = maxHealth;
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
        health -= damage;
        if (health > 0) rb.AddForce(knockbackForceVector * (1 - knockbackResistance / 100), ForceMode2D.Impulse);
        Debug.Log(gameObject.name + ":n Elämä: " + health);
    }

    // Update is called once per frame
    void Update()
    {
        if (iFrames > 0f) { 
            iFrames -= Time.deltaTime;
            sprite.color = new Color(1f, 0.4f, 0.4f, Mathf.Sin(32 * iFrames) / 2 + 0.5f);
            if (iFrames < 0.1f) sprite.color = Color.white;
        }
    }


}
