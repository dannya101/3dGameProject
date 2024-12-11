using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    public Transform pointA; // Reference to an empty GameObject for position A
    public Transform pointB; // Reference to an empty GameObject for position B
    public float speed = 1.0f; // Movement speed

    void Update()
    {
        if (pointA != null && pointB != null) // Ensure the points are assigned
        {
            // PingPong oscillates between 0 and 1
            float t = Mathf.PingPong(Time.time * speed, 1);
            // Lerp between the positions of the two empty GameObjects
            transform.position = Vector3.Lerp(pointA.position, pointB.position, t);
        }
    }
}
