using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineHack : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    SpriteRenderer pSpriteRenderer;
    Pickable pickable;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        pSpriteRenderer = gameObject.transform.parent.GetComponent<SpriteRenderer>();
        pickable = gameObject.GetComponentInParent<Pickable>();
        spriteRenderer.enabled = false;
        spriteRenderer.sprite = pSpriteRenderer.sprite;
    }

    public void Update()
    {
        if (pickable.inPlace)
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }
}
