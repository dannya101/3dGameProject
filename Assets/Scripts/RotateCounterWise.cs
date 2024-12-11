using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class RotatingCountWise : MonoBehaviour
{
    public GameObject objectToRotate;
    private Rigidbody rb;

    private float speed = 30f; 
    private float acceleration = 5f; 
    private float maxSpeed = 50f; 

    private float timer = 0f;
    private bool rotateClockwise = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody is missing on the object to rotate!");
        }
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer >= 5f) // Every 5 seconds
        {
            timer = 0f; // Reset timer
            rotateClockwise = !rotateClockwise; // Toggle rotation direction
            speed = 30f; // Reset speed to initial value
        }
        else
        {
            // Increase speed linearly, but cap it at maxSpeed
            speed = Mathf.Min(speed + acceleration * Time.fixedDeltaTime, maxSpeed);
        }

        // Determine the rotation direction
        float rotationSpeed = rotateClockwise ? speed : -speed;

        if (rb != null)
        {
            // Calculate the new rotation
            Quaternion targetRotation = Quaternion.Euler(
                objectToRotate.transform.eulerAngles.x,
                objectToRotate.transform.eulerAngles.y + rotationSpeed * Time.fixedDeltaTime,
                objectToRotate.transform.eulerAngles.z
            );

            // Apply rotation using Rigidbody
            rb.MoveRotation(targetRotation);
        }

        Debug.Log("Speed: " + speed);
    }
}