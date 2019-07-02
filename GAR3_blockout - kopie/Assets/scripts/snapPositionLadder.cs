using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPositionLadder : MonoBehaviour
{
    
    public GameObject StaticLadder;
    private Rigidbody ladderRigidbody;
    private Vector3 ladderPos = new Vector3(-55.24601f, 3.428934f, -37.59622f);
    private Quaternion ladderRot = Quaternion.Euler(new Vector3(-1.769f, 193.53f, -1.841f));

    void Start()
    {
        //staticLadder = GameObject.Find("ladder_standing(Clone)");
         //ladderRigidbody = staticLadder.GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log("collide");
        //StaticLadder = GameObject.Find("ladder_standing(Clone)");
        ladderRigidbody = StaticLadder.GetComponent<Rigidbody>();
        if (other.gameObject.tag == "Ladder" && !ladderRigidbody.isKinematic == true)
        {
            Debug.Log("snap");
            StaticLadder.transform.SetPositionAndRotation(ladderPos, ladderRot);
            Destroy(ladderRigidbody);
        }
    }
}
