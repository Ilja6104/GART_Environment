using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucketLower : MonoBehaviour
{
    public int hitAmount = 0;
    public GameObject quad;
    private Rigidbody rigidbody;
    
    void Start()
    {
        rigidbody = quad.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
        {
            //quad.transform.position = new Vector3(0.0f, -0.01f, 0.0f);

        }
    private void OnTriggerEnter(Collider other)
    {
        hitAmount += 1;

        if (hitAmount >= 3)
        {
            Debug.Log("loose");
            rigidbody.useGravity = true;
            rigidbody.constraints = RigidbodyConstraints.None;

        }
        else
        {
            Debug.Log("entered");
            quad.transform.position += new Vector3(0, -1, 0);
            
        }
        
        
        
    }


}
