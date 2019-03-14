using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour {
	

	private GameObject uppickedObject;
	private Rigidbody uppickedRigidbody;

	void Update () {
		if(Input.GetMouseButtonDown(1))
		{
			int layerMask = 1 << 8;
			RaycastHit hitInfo;
			if (Physics.Raycast (transform.position + transform.forward, transform.forward, out hitInfo, 3.0f, layerMask)) {
				print (hitInfo.transform.gameObject.name);
				uppickedObject = hitInfo.collider.gameObject;
				uppickedObject.transform.parent = transform;
			
				uppickedRigidbody = uppickedObject.GetComponent<Rigidbody>();
				uppickedRigidbody.isKinematic = true;

			} 
		}
		else if (Input.GetMouseButtonUp(1))
		{
			uppickedRigidbody.isKinematic = false;
			uppickedObject.transform.parent = null;
			uppickedObject = null;
			uppickedRigidbody = null;

		}

	}
	void OnCollisionEnter(Collision collision) 
	{ 
		uppickedRigidbody.isKinematic = false; 
	}




}

