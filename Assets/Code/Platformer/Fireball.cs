using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    bool fly = false;
    bool dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Shoot(float delay, bool direction)
    {
        StartCoroutine(IEShoot(delay));
        dir = direction;
    }

    IEnumerator IEShoot(float delay)
    {
        yield return new WaitForSeconds(delay);
        fly = true;

        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (fly && dir)
        {
            transform.position = new Vector2(transform.position.x + Time.deltaTime * 10, transform.position.y);
        }
        else if (fly)
        {
            transform.position = new Vector2(transform.position.x - Time.deltaTime * 10, transform.position.y);
        }
    }
}
