using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] [Range(0, 2)] int id;
    Animator anim;
    bool collected = false;
    // Start is called before the first frame update
    void Start()
    {
        if (
            ( (GameManager.levels[GameManager.currentLevel] & 0b_100) == 0b_100 && id == 0 ) ||
            ( (GameManager.levels[GameManager.currentLevel] & 0b_1000) == 0b_1000 && id == 1 ) ||
            ( (GameManager.levels[GameManager.currentLevel] & 0b_10000) == 0b_10000 && id == 2 )
        )
        Destroy(gameObject);

        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !collected)
        {
            collected = true;
            anim.Play("CollectibleCollect");
            switch (id)
            {
                case 0 :
                    GameManager.levels[GameManager.currentLevel] |= 0b_100;
                    break;
                case 1 :
                    GameManager.levels[GameManager.currentLevel] |= 0b_1000;
                    break;
                case 2 :
                    GameManager.levels[GameManager.currentLevel] |= 0b_10000;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
