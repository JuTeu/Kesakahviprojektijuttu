using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    Rigidbody2D rb;
    int maxMagicPower = 10;
    int magicPower;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject fireSpell;
    bool spellCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        magicPower = maxMagicPower;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainMagicPower(int amount)
    {
        magicPower += amount;
        if (magicPower > maxMagicPower) magicPower = maxMagicPower;
    }

    public void CastMagic(bool input, Vector2 moveInput)
    {
        if (input && !spellCooldown)
        {
            spellCooldown = true;
            if (magicPower >= 2)
            {
                StartCoroutine(FireSpell());
                magicPower -= 2;
            }
            else
            {
                spellCooldown = false;
            }
            Debug.Log("MP: " + magicPower);
        }
    }

    IEnumerator FireSpell()
    {
        Vector2 spellPosition;
        Quaternion spellRotation = new Quaternion();
        //rb.constraints = RigidbodyConstraints2D.FreezeAll;
        if (sprite.flipX)
        {
            spellPosition = new Vector2(transform.position.x + 2, transform.position.y + 2.5f);
            spellRotation.eulerAngles = new Vector3(0, -40, 0); 
        }
        else
        {
            spellPosition = new Vector2(transform.position.x - 2, transform.position.y + 2.5f);
            spellRotation.eulerAngles = new Vector3(0, 40, 0);
        }
        Instantiate(fireSpell, spellPosition, spellRotation);
        yield return new WaitForSeconds(5f);
        //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        spellCooldown = false;
    }
}
