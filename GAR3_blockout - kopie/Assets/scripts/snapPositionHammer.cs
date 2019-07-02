using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPositionHammer : MonoBehaviour
{

    public GameObject StaticHammer;
    private Vector3 hammerPos = new Vector3(-38.106f, 3.581f, -33.657f);
    private Quaternion hammerRot = Quaternion.Euler(new Vector3(0.0f, -36.236f, -90.00001f));
    private Rigidbody hammerRigidbody;

    void Start()
    {
        hammerRigidbody = StaticHammer.GetComponent<Rigidbody>();
    }

     void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Hammer" && !hammerRigidbody.isKinematic == true)
        {
            StaticHammer.transform.SetPositionAndRotation(hammerPos, hammerRot);
            Destroy(hammerRigidbody);
            PalletScript.Instance.HammerContact = true;
        }
    }
}
