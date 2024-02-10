using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    Rigidbody rb;
    public float maxDistance = 1f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerStay(Collider other)
    {
        //object is grabbed when tweezers are closed around it
        if (other.GetComponent<Tweezers>() != null && other.GetComponent<Tweezers>().grabbing)
        {
            rb.useGravity = false;
            rb.transform.parent = other.GetComponent<Tweezers>().grabPoint.transform;
        }
    }
    private void Update()
    {
        //drop object if tweezers open
        if (Input.GetMouseButtonUp(0))
        {
            rb.useGravity = true;
            rb.transform.parent = null;
        }
        //drop object if tweezers too far
        if (transform.parent != null)
        {
            if (Vector3.Distance(rb.transform.position, rb.transform.parent.position) > maxDistance)
            {
                rb.useGravity = true;
                rb.transform.parent = null;
            }
        }
    }
}
