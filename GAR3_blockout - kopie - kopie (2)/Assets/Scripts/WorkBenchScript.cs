using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBenchScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hammer")
        {
            GameObject.Find("pallet").GetComponent<PalletScript>().HammerContact = true;
        }
    }
}
