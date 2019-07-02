using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public GameObject Player;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Player.transform.position, transform.position);



        if(dist <= 10.0f)
        {
            Debug.Log("Animate");
            animator.SetBool("closeEnough", true);
            Debug.Log("true");
        } 
        else
        {
            animator.SetBool("closeEnough", false);
            Debug.Log("false");
        }
    }

}
