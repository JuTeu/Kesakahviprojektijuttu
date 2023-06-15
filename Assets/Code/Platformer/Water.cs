using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] SpriteRenderer render;
    [SerializeField] GameObject splashPrefab;
    MaterialPropertyBlock propertyBlock;
    
    void Awake()
    {
        propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetFloat("_Width", transform.lossyScale.x);
        propertyBlock.SetFloat("_Height", transform.lossyScale.y);
        render.SetPropertyBlock(propertyBlock);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
        Instantiate(splashPrefab, collision.gameObject.transform.position, Quaternion.identity);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
        Instantiate(splashPrefab, collision.gameObject.transform.position, Quaternion.identity);
    }
}
