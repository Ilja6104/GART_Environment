using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterScript : MonoBehaviour {
   
    public GameObject bulletPrefab;
	public int bulletCount = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
			if(bulletCount > 0)
			{
				
				print("shootyshoot");
				bulletCount -= 1;
				GameObject currentBullet = Instantiate(bulletPrefab, transform.position,Quaternion.identity);
				currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 7f);
				currentBullet.name = "Bullet";
			}

        }
        print(bulletCount);
    }
    
}
