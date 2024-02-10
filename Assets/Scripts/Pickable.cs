using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    Rigidbody rb;
    Vector3 currentPos;
    Vector3 targerPos;
    Vector3 directionOfTravel;
    public float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Tweezers>() != null) {
            if (other.GetComponent<Tweezers>().grabbing)
            {
                rb.useGravity = false;
                rb.MovePosition(other.GetComponent<Tweezers>().grabPoint.transform.position);
            }
            else
            {
                rb.useGravity = true;
            }
        }
        else
        {
            rb.useGravity = true;
        }
    }
}
