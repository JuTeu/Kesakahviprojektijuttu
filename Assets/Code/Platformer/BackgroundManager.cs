using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] renderers;
    MaterialPropertyBlock[] propertyBlocks;
    // Start is called before the first frame update
    void Start()
    {
        propertyBlocks = new MaterialPropertyBlock[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
        {
            propertyBlocks[i] = new MaterialPropertyBlock();
            renderers[i].GetPropertyBlock(propertyBlocks[i]);
        }
        
        ChangeBackground(-1);
    }

    public void ChangeBackground(int level)
    {
        if (level == -1)
        {
            renderers[1].color = new Color(0.15f, 0.61f, 0.97f);

            renderers[1].color = new Color(0.26f, 0.26f, 0.26f);
            propertyBlocks[1].SetFloat("_Scaling", 30);
            propertyBlocks[1].SetFloat("_HorizontalScrollOffset", 35);
            propertyBlocks[1].SetFloat("_VerticalScrollOffset", 35);
            propertyBlocks[1].SetFloat("_HorizontalOffset", 0.5f);
            propertyBlocks[1].SetFloat("_VerticalOffset", -0.6f);
            propertyBlocks[1].SetFloat("_TopClamp", 0.5f);
            propertyBlocks[1].SetFloat("_BottomClamp", -0.2f);

            renderers[2].color = new Color(0.36f, 0.36f, 0.36f);
            propertyBlocks[2].SetFloat("_Scaling", 15);
            propertyBlocks[2].SetFloat("_HorizontalScrollOffset", 20);
            propertyBlocks[2].SetFloat("_VerticalScrollOffset", 20);
            propertyBlocks[2].SetFloat("_HorizontalOffset", 0.3f);
            propertyBlocks[2].SetFloat("_VerticalOffset", -0.5f);
            propertyBlocks[2].SetFloat("_TopClamp", 0.4f);
            propertyBlocks[2].SetFloat("_BottomClamp", -0.4f);
        }
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].SetPropertyBlock(propertyBlocks[i]);
        }
    }
}
