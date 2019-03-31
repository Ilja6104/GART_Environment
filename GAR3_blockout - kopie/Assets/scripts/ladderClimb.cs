
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class ladderClimb : MonoBehaviour
{
    public bool ladderTouch = false;
    public GameObject player;
    private Rigidbody playerRigidbody;
    private float climbingSpeed = 3;
    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        if (Input.GetKey("w") && ladderTouch == true)
        {
            Debug.Log("climbing");
            //player.transform.position += new Vector3(0, 0, 80);
            // player.transform.Translate(Vector3.up * 60 * Time.deltaTime);
            //playerRigidbody.useGravity = false;
            //playerRigidbody.isKinematic = false;
            //player.transform.Translate(Vector3.up * CrossPlatformInputManager.GetAxis("Vertical") *
            //climbingSpeed * Time.deltaTime);
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MoveDir.y = 5;
        }
        else
        {
            playerRigidbody.useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide ladder climb");
        if (other.gameObject.tag == "Player")
        {
            ladderTouch = true;
            Debug.Log("touching");
        }
       

    }

    private void OnTriggerExit(Collider other)
    {
        ladderTouch = false;
    }
}


