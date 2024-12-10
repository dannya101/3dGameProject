using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
public class RotatingClockWise: MonoBehaviour
{
    public GameObject objectToRotate;
    Quaternion targetRotation;
    private  int speed = 1;
    float timer = 0f;
    float tolerance = 0.01f; // Define a small tolerance


    void Update()
    {
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        // if(Time.time >= 10)
        // {

           

        // if (Mathf.Abs(Time.time % 5) < tolerance) // Check if close to a multiple of 5
        // {
        //     speed = 1;
        // }
        // else
        // {
        //     speed = -1;
        // }
        // }
        targetRotation = Quaternion.Euler(objectToRotate.transform.eulerAngles.x, objectToRotate.transform.eulerAngles.y - speed, objectToRotate.transform.eulerAngles.z);
        objectToRotate.transform.rotation = targetRotation;
    }
}