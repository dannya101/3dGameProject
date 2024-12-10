using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 10;  // Amount to increase the score

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

