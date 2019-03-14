using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Rigidbody forceApply = GetComponent<Rigidbody> ();

		forceApply.AddForce(Random.Range(-10, 10), Random.Range(-10, 10), 0,  ForceMode.Impulse);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
