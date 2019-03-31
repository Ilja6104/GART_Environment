using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapPositionHammer : MonoBehaviour
{

    public GameObject staticHammer;
    private Vector3 hammerPos = new Vector3(-38.106f, 3.975f,-33.657f);
    private Quaternion hammerRot = Quaternion.Euler(new Vector3(0.0f, -36.236f, -90.00001f));
    private Rigidbody hammerRigidbody;



    void Start()
    {
        hammerRigidbody = staticHammer.GetComponent<Rigidbody>();
       
    }

     void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Hammer" && !hammerRigidbody.isKinematic == true)
        {
            
            staticHammer.transform.SetPositionAndRotation(hammerPos, hammerRot);
            Destroy(hammerRigidbody);
            GameObject.Find("pallet").GetComponent<palletScript>().hammerContact = true;

            //staticHammer.gameObject.SetActive(true);
        }
    }
}
