using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] SpriteRenderer render;
    [SerializeField] GameObject splashPrefab;
    MaterialPropertyBlock propertyBlock;
    bool finishedChanging = true;
    
    void Awake()
    {
        propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetFloat("_Width", transform.lossyScale.x);
        propertyBlock.SetFloat("_Height", transform.lossyScale.y);
        render.SetPropertyBlock(propertyBlock);
    }

    public void ChangeLevel(float height)
    {
        if (!finishedChanging) return;
        finishedChanging = false;
        StartCoroutine(ChangingLevel(height));
    }

    public void ChangeLevelInstant(float height)
    {
        if (!finishedChanging) return;
        transform.position = new Vector2(transform.position.x, height);
    }

    IEnumerator ChangingLevel(float targetHeight)
    {
        while(transform.position.y != targetHeight)
        {
            transform.position = new Vector2(transform.position.x,
            Mathf.MoveTowards(transform.position.y, targetHeight,
                            Time.deltaTime));
            yield return new WaitForEndOfFrame();
        }
        finishedChanging = true;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
        Instantiate(splashPrefab, collision.gameObject.transform.position,
                    Quaternion.identity);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
        Instantiate(splashPrefab, collision.gameObject.transform.position,
                    Quaternion.identity);
    }
}
