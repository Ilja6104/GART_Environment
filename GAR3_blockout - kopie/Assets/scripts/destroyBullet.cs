using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour {
	public GameObject explosionPrefab;
	void OnCollisionEnter(Collision collision)
	{
		Instantiate(explosionPrefab, transform.position,Quaternion.identity);
		Destroy(gameObject);

	}
		

}
