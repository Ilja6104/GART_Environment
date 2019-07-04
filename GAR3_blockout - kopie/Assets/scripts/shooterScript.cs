using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour {
   
    public GameObject bulletPrefab;
	public int BulletCount = 10;
	
	void Update () {

		if(Input.GetMouseButtonDown(0))
        {
			if(BulletCount > 0)
			{
				BulletCount -= 1;
				GameObject currentBullet = Instantiate(bulletPrefab, transform.position + transform.forward * 1, Quaternion.identity);
				currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 7f);
				currentBullet.name = "Bullet";

                FindObjectOfType<AudioManager>().Play("Throw");
            }
        }
    }
}
