using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailToggle : MonoBehaviour
{
    public Sprite sailOpen;
    public Sprite sailClosed;
    public SpriteRenderer sailSpriteRenderer;
    public BoxCollider hitBoxOpen;
    public BoxCollider hitBoxClosed;
    public bool isSailOpen;
    // Start is called before the first frame update
    void Start()
    {
        isSailOpen = false;
        ToggleSail();
    }

    public void ToggleSail()
    {
        if (isSailOpen) {
            sailSpriteRenderer.sprite = sailClosed;
            hitBoxClosed.enabled = true;
            hitBoxOpen.enabled = false;
            
        }
        else {
            sailSpriteRenderer.sprite = sailOpen;
            hitBoxClosed.enabled = false;
            hitBoxOpen.enabled = true;
        }
        isSailOpen = !isSailOpen;
    }
}
