using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //CIBLE : CAMERA
    private int SpeedRotate = 1;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
            transform.LookAt(target);
            //transform.Translate(Vector3.right * Time.deltaTime);
            transform.Translate(Vector3.right * SpeedRotate);
        }
        if (Input.GetKey("d"))
        {
            transform.LookAt(target);
            transform.Translate(Vector3.left * (SpeedRotate));
        }
        
    }
}
