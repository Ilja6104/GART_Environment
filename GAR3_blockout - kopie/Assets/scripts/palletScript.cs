using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PalletScript : MonoBehaviour
{
    public static PalletScript Instance{get; private set;}

    public List<Collider> StepList = new List<Collider>();
    public List<Collider> SidesList = new List<Collider>();
    public GameObject Ladder;
    public bool HammerContact = false;

    int plankCount = 0;
    int sidesCount = 0;
    
    private Vector3 ladderPos = new Vector3(-32.95f, -1.87f, -30.35f);
    private Quaternion ladderRot = Quaternion.Euler(new Vector3(-0.724f, 184.306f, -91.146f));


    private void Start()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!StepList.Contains(other) && other.tag == "LadderStep")
        {
            plankCount = 0;
            StepList.Add(other);
            foreach (var plank in StepList)
            {
                plankCount += 1;
            }

        }
        if (!SidesList.Contains(other) && other.tag == "SidesStep")
        {
            sidesCount = 0;
            SidesList.Add(other);
            foreach (var side in SidesList)
            {
                sidesCount += 1;
            }
        }

    }

    void Update()
    {
        List<GameObject> ObjectsToDestroy = new List<GameObject>();

        if (plankCount >= 5 && sidesCount >= 2 && HammerContact == true)
        {
            foreach (var plank in StepList)
            {
                if (plank != null) ObjectsToDestroy.Add(plank.gameObject);
            }
            foreach (var side in SidesList)
            {
                if (side != null) ObjectsToDestroy.Add(side.gameObject);
            }

            Instantiate(Ladder, ladderPos, ladderRot);
            FindObjectOfType<AudioManager>().Play("Build");
            plankCount = 0;
            sidesCount = 0;
        }

        foreach (GameObject go in ObjectsToDestroy)
        {
            if(go != null) Destroy(go);
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
        }
    }
}
