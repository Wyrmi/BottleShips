using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    Rigidbody rb;
    public float maxTweezerDistance = 1f;
    public float maxRightPlaceDistance = 0.3f;
    public GameObject rightPlace;
    public GameObject pivotPoint;
    public bool inPlace;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        //failsafe
        if (pivotPoint == null)
            pivotPoint = gameObject;
        if (rightPlace == null)
            rightPlace = gameObject;
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
        if (transform.parent != null)
        {
            //drop object if tweezers too far
            if (Vector3.Distance(rb.transform.position, rb.transform.parent.position) > maxTweezerDistance)
            {
                rb.useGravity = true;
                rb.transform.parent = null;
            }
            //rotate object by 45 degrees on z axis on right click
            if (Input.GetMouseButtonUp(1))
                rb.transform.Rotate(0f, 0.0f, 45.0f, Space.Self);
        }
        //check if part is where it should be and in the right way
        if (Vector3.Distance(pivotPoint.transform.position, rightPlace.transform.position) < maxRightPlaceDistance)
            inPlace = true;
        else
            inPlace = false;
    }
}
