using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
public class RotatingCounterWise: MonoBehaviour
{
    public GameObject objectToRotate;
    Quaternion targetRotation;
    public int speed = 1;

    void Update()
    {

    }
    void FixedUpdate()
    {
        if(Time.deltaTime % 5 == 0)
        {
            speed = -1;
            targetRotation = Quaternion.Euler(objectToRotate.transform.eulerAngles.x, objectToRotate.transform.eulerAngles.y - speed, objectToRotate.transform.eulerAngles.z);
            objectToRotate.transform.rotation = targetRotation;
        }
        else
        {
            speed = 1;
            targetRotation = Quaternion.Euler(objectToRotate.transform.eulerAngles.x, objectToRotate.transform.eulerAngles.y - speed, objectToRotate.transform.eulerAngles.z);
            objectToRotate.transform.rotation = targetRotation;
        }
    }
}