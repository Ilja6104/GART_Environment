using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class workBenchScript : MonoBehaviour
{
   

  

    public List<Collider> StepList = new List<Collider>();
    public List<Collider> SidesList = new List<Collider>();
    int plankCount = 0;
    int sidesCount = 0;
    public GameObject ladder;

    private void OnTriggerEnter(Collider other)
    {

        //print(TriggerList);
        if (!StepList.Contains(other) && other.tag == "LadderStep")
        {
            plankCount = 0;
            StepList.Add(other);
            foreach (var plank in StepList)
            {
                plankCount += 1;
            }
            print("planks: " + plankCount);
            //print("added" + other);
           
        }
        if(!SidesList.Contains(other) && other.tag == "SidesStep")
        {
            sidesCount = 0;
            SidesList.Add(other);
            foreach (var side in SidesList)
            {

                sidesCount += 1;
            }
            print("sides: " + sidesCount);
            //print("added" + other);
        }

        if(plankCount >= 5 && sidesCount >= 2)
        {
            foreach (var plank in StepList)
            {
                Destroy(plank.gameObject);
            }
            foreach (var side in SidesList)
            {
                Destroy(other.gameObject); 
            }
            Instantiate(ladder, new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z), Quaternion.identity);
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
       
        if (StepList.Contains(other) && other.tag == "LadderStep")
        {
            plankCount = 0;
            StepList.Remove(other);
            foreach (var plank in StepList)
            {
                plankCount += 1;
            }
            print("planks: " +plankCount);
           //print("removed" + other); 
        }

        if (!SidesList.Contains(other) && other.tag == "SidesStep")
        {
            sidesCount = 0;
            SidesList.Remove(other);
            foreach (var side in SidesList)
            {

                sidesCount += 1;
            }
            print("sides: " + sidesCount);
            //print("added" + other);
        }
    }
}