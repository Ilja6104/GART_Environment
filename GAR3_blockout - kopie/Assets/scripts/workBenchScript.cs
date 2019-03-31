using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class workBenchScript : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("enter");
        if (other.gameObject.tag == "Hammer")
        {
            GameObject.Find("pallet").GetComponent<palletScript>().hammerContact = true;
            //Debug.Log("hammertouch");
        }

    }
}
