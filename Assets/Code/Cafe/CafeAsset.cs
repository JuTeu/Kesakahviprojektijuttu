using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeAsset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnValidate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y - 0.5f);
        float scale = 1 - transform.position.y * GameManager.cafeScalingModifier;
        transform.localScale = new Vector2(scale, scale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
