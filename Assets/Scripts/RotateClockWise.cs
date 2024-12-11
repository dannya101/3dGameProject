using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class RotatingClockWise : MonoBehaviour
{
    public GameObject objectToRotate;
    private Quaternion targetRotation;
    private float speed = 10f; // Initial speed
    private float timer = 0f;
    private float tolerance = 0.01f; // Define a small tolerance
    public Rigidbody rb;
    private bool rotateClockwise = true;
    private float acceleration = 5f; // How much the speed increases per second

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
        }

        // Increase the speed linearly
        speed += acceleration * Time.fixedDeltaTime;

        // Determine the rotation direction
        float rotationSpeed = rotateClockwise ? speed : -speed;

        Debug.Log("Speed: " + rotationSpeed);

        if (rb != null)
        {
            // Calculate the new rotation
            Quaternion targetRotation = Quaternion.Euler(
                objectToRotate.transform.eulerAngles.x,
                objectToRotate.transform.eulerAngles.y - rotationSpeed * Time.fixedDeltaTime,
                objectToRotate.transform.eulerAngles.z
            );

            // Apply rotation using Rigidbody
            rb.MoveRotation(targetRotation);
        }
    }
}