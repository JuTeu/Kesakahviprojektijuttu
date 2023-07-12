using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSprite: MonoBehaviour
{
    // unityss‰ asettaa sopiva tietoisku/inf0
    [SerializeField] private SpriteRenderer newInfo;

    void Start()
    {
        newInfo.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // t‰h‰n koodi, joka n‰ytt‰‰ uuden info triggerin tapahtuessa
        // newInfo.SetActive(true);
        //Debug.Log("collision" + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            newInfo.enabled = true;
        }
        
    }

    void OnTriggerExit2D()
    {
        newInfo.enabled = false;
    }

}
