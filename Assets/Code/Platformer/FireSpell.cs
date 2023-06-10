using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour
{
    [SerializeField] Transform[] smallPentagrams;
    [SerializeField] GameObject projectile;
    bool facing = false;
    
    IEnumerator Start()
    {
        if (transform.rotation.y > 0) facing = true;
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < 5; i++)
        {
            foreach (Transform pentagram in smallPentagrams)
            {
                GameObject newProjectile;
                newProjectile = Instantiate(projectile, pentagram.position, Quaternion.identity);
                newProjectile.GetComponent<Fireball>().Shoot(0.1f, facing ? 0 : 180);
                yield return new WaitForSeconds(0.1f);
            }
        }
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
