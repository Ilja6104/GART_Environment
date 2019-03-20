using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class workBenchScript : MonoBehaviour
{
   

    //The list of colliders currently inside the trigger

    public List<Collider> TriggerList = new List<Collider>();


    //called when something enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        print(TriggerList);
        //if the object is not already in the list
        if (!TriggerList.Contains(other))
        {
            //add the object to the list
            TriggerList.Add(Other);
        }
    }

    //called when something exits the trigger
    private void OnTriggerExit(Collider other)
    {
        //if the object is in the list
        if (TriggerList.Contains(other))
        {
            //remove it from the list
            TriggerList.Remove(Other);
        }
    }
}