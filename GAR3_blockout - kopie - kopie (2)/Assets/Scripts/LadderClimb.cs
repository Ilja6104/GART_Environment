
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class LadderClimb : MonoBehaviour
{
    public bool LadderTouch = false;
    public GameObject Player;
    private Rigidbody playerRigidbody;
    private float climbingSpeed = 3;

    void Start()
    {
        playerRigidbody = Player.GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKey("w") && LadderTouch == true)
        {
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MoveDir.y = 5;
        }
        else
        {
            playerRigidbody.useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LadderTouch = true;
            Debug.Log("touching");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        LadderTouch = false;
    }
}


