
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketLower : MonoBehaviour
{
    public int HitAmount = 0;
    public GameObject Quad;
    private Rigidbody rigidbody;
    private bool entered = false;
    private float fallspeed = 0.05f;
    private Vector3 lerpPosition;

    void Start()
    {
        rigidbody = Quad.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (entered == true)
        {
            Quad.transform.position = Vector3.Lerp(Quad.transform.position, lerpPosition, fallspeed);
            if (fallspeed == 1)
            {
                entered = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HitAmount += 1;

        if (other.gameObject.layer == 10)
        {
            other.gameObject.layer = 0;
            if (HitAmount >= 4)
            {
                lerpPosition = Quad.transform.position + new Vector3(0, -4.7f, 0);
                fallspeed = 0.01f;
            }
            else
            {
                lerpPosition = Quad.transform.position + new Vector3(0, -0.2f, 0);
                entered = true;
            }
        }
    }
}

