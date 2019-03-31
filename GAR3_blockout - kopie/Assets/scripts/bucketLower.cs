
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucketLower : MonoBehaviour
{
    public int hitAmount = 0;
    public GameObject quad;
    private Rigidbody rigidbody;
    private bool entered = false;
    private float fallspeed = 0.05f;
    private Vector3 lerpPosition;

    void Start()
    {
        rigidbody = quad.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (entered == true)
        {
            Debug.Log(fallspeed);
            quad.transform.position = Vector3.Lerp(quad.transform.position, lerpPosition, fallspeed);
            if (fallspeed == 1)
            {
                entered = false;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        hitAmount += 1;

        if (other.gameObject.layer == 10)
        {
            other.gameObject.layer = 0;
            if (hitAmount >= 3)
            {
                Debug.Log("loose");
                //rigidbody.useGravity = true;
                //rigidbody.constraints = RigidbodyConstraints.None;
                lerpPosition = quad.transform.position + new Vector3(0, -5.2f, 0);
                fallspeed = 0.01f;
                //entered = true;



            }
            else
            {
                Debug.Log("entered");
                lerpPosition = quad.transform.position + new Vector3(0, -0.2f, 0);
                entered = true;

                //quad.transform.position = Vector3.Lerp(quad.transform.position, quad.transform.position + new Vector3(0, -4, 0), 0.01f); 
                //quad.transform.position = Vector3.Lerp(quad.transform.position, quad.transform.position + new Vector3(0, -1.2f, 0), fallspeed);
            }
        }


    }


}

