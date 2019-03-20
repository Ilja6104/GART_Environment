using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickerScript : MonoBehaviour {
    private GameObject uppickedObject;
    private Rigidbody uppickedRigidbody;
    public float range = 10.0f;
    private float startingMass;
   

    private void Update()
	{
        int pickupLayerMask = 1 << 8;
        int projectileLayerMask = 1 << 10;
        
        if (Input.GetMouseButtonDown(1)) 
		{
            
            RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            print("hitIt");
            if (Physics.Raycast (ray, out hit, range, pickupLayerMask)) 
			{
                
                print(hit.transform.gameObject.name);
                uppickedObject = hit.collider.gameObject;
                uppickedObject.transform.parent = transform;

                uppickedRigidbody = uppickedObject.GetComponent<Rigidbody>();
                //startingMass = uppickedRigidbody.mass;
                uppickedRigidbody.isKinematic = true;
               // uppickedRigidbody.mass = 0;
                uppickedRigidbody.useGravity = false;
                //uppickedRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            }
            if (Physics.Raycast(ray, out hit, range, projectileLayerMask))
            {
                print("pickItUp");
                print(hit.transform.gameObject.name);
                GameObject.Find("FirstPersonCharacter").GetComponent<shooterScript>().bulletCount += 1;
                uppickedObject = hit.collider.gameObject;
                Destroy(uppickedObject);

            }


        }
        else if (Input.GetMouseButtonUp(1))
        {
            uppickedRigidbody.isKinematic = false;
            //uppickedRigidbody.mass = startingMass;
            uppickedRigidbody.useGravity = true;
            //uppickedRigidbody.constraints = RigidbodyConstraints.None;


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

