using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class palletScript : MonoBehaviour
{

    public List<Collider> StepList = new List<Collider>();
    public List<Collider> SidesList = new List<Collider>();
    int plankCount = 0;
    int sidesCount = 0;
    public GameObject ladder;
    public bool hammerContact = false;

    private Vector3 ladderPos = new Vector3(-32.95f, -1.87f, -30.35f);
    private Quaternion ladderRot = Quaternion.Euler(new Vector3(-0.724f, 184.306f, -91.146f));

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
            //print("planks: " + plankCount);
            //print("added" + other);

        }
        if (!SidesList.Contains(other) && other.tag == "SidesStep")
        {
            sidesCount = 0;
            SidesList.Add(other);
            foreach (var side in SidesList)
            {

                sidesCount += 1;
            }
            //print("sides: " + sidesCount);
            //print("added" + other);
        }


    }
    void Update()
    {
        if (plankCount >= 5 && sidesCount >= 2 && hammerContact == true)
        {
            //Debug.Log("assemble");
            foreach (var plank in StepList)
            {
                Destroy(plank.gameObject);
            }
            foreach (var side in SidesList)
            {
                Destroy(side.gameObject);
            }

            Instantiate(ladder, ladderPos, ladderRot);

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
            print("planks: " + plankCount);
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
