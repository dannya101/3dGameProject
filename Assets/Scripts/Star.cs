using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public int scoreValue = 100;  // Amount to increase the score


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the coin around its Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Ensure only the player can collect the coin
        {
            // Increase the score or time
            Timer timer = FindObjectOfType<Timer>();
            if (timer != null)
            {
                timer.AddTime(scoreValue);  // Add time to the timer
            }

            // Destroy the coin
            Destroy(gameObject);
        }
    }
}
