using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    SpriteRenderer sprite;
    Vector3 previousPosition;
    [SerializeField] float frequency = 0.5f, lifeTime = 1.5f;
    [SerializeField] Color initialColor = Color.white, finalColor = new Color (1, 1, 1, 0);

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();    
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, previousPosition) > frequency)
        {
            NewAfterImage();
        }
    }

    void NewAfterImage()
    {
        previousPosition = transform.position;

        GameObject newAfterImage = new GameObject(gameObject.name + " after image");
        SpriteRenderer newAfterImageSprite = newAfterImage.AddComponent<SpriteRenderer>();
        Vector3 spritePosition = transform.position;
        spritePosition.z += 0.1f;
        newAfterImage.transform.position = spritePosition;
        newAfterImage.transform.rotation = transform.rotation;
        newAfterImage.transform.localScale = transform.lossyScale;

        newAfterImageSprite.color = initialColor;
        newAfterImageSprite.sprite = sprite.sprite;
        newAfterImageSprite.flipX = sprite.flipX;
        newAfterImageSprite.flipY = sprite.flipY;
        newAfterImageSprite.sortingOrder = sprite.sortingOrder;
        StartCoroutine(Fade(newAfterImageSprite));
    }

    IEnumerator Fade(SpriteRenderer afterImage)
    {
        float timeElapsed = 0;
        while (timeElapsed < lifeTime)
        {
            afterImage.color = Color.Lerp(initialColor, finalColor, timeElapsed / lifeTime);
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Destroy(afterImage.gameObject);
    }
}
