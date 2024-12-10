using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
public class RotatingCise: MonoBehaviour
{
    public GameObject objectToRotate;
    Quaternion targetRotation;
    private  int speed = 30;
    float timer = 0f;
    float tolerance = 0.01f; // Define a small tolerance
    private Rigidbody rb;

    void Start(){
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody is missing on the object to rotate!");
        }
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5f) // Every 5 seconds
        {
            timer = 0f; // Reset timer
            speed = 30;
        }
        else
        {
            speed = -30;
        }
        Debug.Log("Speed: " + speed);
    }
    void FixedUpdate()
    {
        if (rb != null)
        {
            // Calculate the new rotation
            Quaternion targetRotation = Quaternion.Euler(
                objectToRotate.transform.eulerAngles.x,
                objectToRotate.transform.eulerAngles.y - speed * Time.fixedDeltaTime,
                objectToRotate.transform.eulerAngles.z
            );

            // Apply rotation using Rigidbody
            rb.MoveRotation(targetRotation);
        }
    }
}