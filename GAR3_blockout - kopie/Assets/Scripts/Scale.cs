using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Scale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.localScale = transform.localScale/100;
        transform.eulerAngles = new Vector3(90,0,0);
        //transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
