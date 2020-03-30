using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickerScript : MonoBehaviour {

    public float Range = 10.0f;
    private GameObject uppickedObject;
    private Rigidbody uppickedRigidbody;
    private float startingMass;
   

    private void Update()
	{
        int pickupLayerMask = 1 << 8;
        int projectileLayerMask = 1 << 10;
        
        if (Input.GetMouseButtonDown(1)) 
		{
            RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
           
            if (Physics.Raycast (ray, out hit, Range, pickupLayerMask)) 
			{
                uppickedObject = hit.collider.gameObject;
                uppickedObject.transform.parent = transform;

                uppickedRigidbody = uppickedObject.GetComponent<Rigidbody>();
                uppickedRigidbody.isKinematic = true;
                uppickedRigidbody.useGravity = false;
            }

            if (Physics.Raycast(ray, out hit, Range, projectileLayerMask))
            {
                print(hit.transform.gameObject.name);
                this.GetComponent<ShooterScript>().BulletCount += 1;
                uppickedObject = hit.collider.gameObject;
                Destroy(uppickedObject);
            }
        }

        else if (Input.GetMouseButtonUp(1))
        {
            uppickedRigidbody.isKinematic = false;
            uppickedRigidbody.useGravity = true;
            uppickedObject.transform.parent = null;
            uppickedObject = null;
            uppickedRigidbody = null;
        }
    }

	private void PrintName(GameObject go)
	{
		print (go.name);
	}
}

