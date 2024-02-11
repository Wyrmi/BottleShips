using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    Rigidbody rb;
    public float maxTweezerDistance = 1f;
    public float maxRightPlaceDistance = 0.2f;
    public GameObject rightPlace;
    public GameObject pivotPoint;
    public bool inPlace;
    public SailToggle sailToggle;
    Vector3 resetPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        resetPos = transform.position;
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
            if (Input.GetMouseButtonDown(1))
                rb.transform.Rotate(0f, 0.0f, 45.0f, Space.Self);
            //if object is a sail, toggle sail from middle mouse button
            if (Input.GetMouseButtonDown(2) && sailToggle != null)
            {
                sailToggle.ToggleSail();
            }
        }
        //check if part is where it should be and in the right way
        if (Vector3.Distance(pivotPoint.transform.position, rightPlace.transform.position) < maxRightPlaceDistance)
            inPlace = true;
        else
            inPlace = false;
        //reset position if dropped out of bounds
        if (transform.parent == null && !GetComponentInChildren<SpriteRenderer>().isVisible)
        {
            gameObject.transform.position = resetPos;
        }
    }

    //called from game manager when ship is assembled. freezes part in place
    public void EndDrop()
    {
        rb.transform.parent = null;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        this.enabled = false;
    }
}
