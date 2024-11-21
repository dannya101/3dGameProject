using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
public class RotatingClockWise: MonoBehaviour
{
    public GameObject objectToRotate;
    Quaternion targetRotation;
    public int speed = 1;

    void Update()
    {
    }
    void FixedUpdate()
    {
        targetRotation = Quaternion.Euler(objectToRotate.transform.eulerAngles.x, objectToRotate.transform.eulerAngles.y + speed, objectToRotate.transform.eulerAngles.z);
        objectToRotate.transform.rotation = targetRotation;
    }
}