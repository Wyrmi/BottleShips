using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweezers : MonoBehaviour
{
    Vector3 pos;
    public float zpos;
    public Sprite tweezersOpen;
    public Sprite tweezersClosed;
    public SpriteRenderer sr;
    public bool grabbing;
    public GameObject grabPoint;
    void Update()
    {
        //tweezers follow mouse
        pos = Input.mousePosition;
        pos.z = zpos;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
        //tweezers open and close with left mouse button
        if (Input.GetMouseButton(0))
        {
            sr.sprite = tweezersClosed;
            grabbing = true;
        }
        else
        {
            sr.sprite = tweezersOpen;
            grabbing = false;
        }
    }
}
