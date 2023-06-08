using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject fireSpell;
    bool spellCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CastMagic(bool input, Vector2 moveInput)
    {
        if (input && !spellCooldown)
        {
            spellCooldown = true;
            StartCoroutine(FireSpell());
        }
    }

    IEnumerator FireSpell()
    {
        Vector2 spellPosition;
        Quaternion spellRotation = new Quaternion();
        //rb.constraints = RigidbodyConstraints2D.FreezeAll;
        if (sprite.flipX)
        {
            spellPosition = new Vector2(transform.position.x + 2, transform.position.y + 2);
            spellRotation.eulerAngles = new Vector3(0, -40, 0); 
        }
        else
        {
            spellPosition = new Vector2(transform.position.x - 2, transform.position.y + 2);
            spellRotation.eulerAngles = new Vector3(0, 40, 0);
        }
        Instantiate(fireSpell, spellPosition, spellRotation);
        yield return new WaitForSeconds(5f);
        //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        spellCooldown = false;
    }
}
