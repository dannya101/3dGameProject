using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coinPrefab;  // Reference to the coin prefab
    public int maxCoins = 5;       // Number of coins to maintain
    public Vector3 spawnArea = new Vector3(9, 0, 8);  // Define the area for spawning coins

    private void Start()
    {
        for (int i = 0; i < maxCoins; i++)
        {
            SpawnCoin();
        }
    }

    private void Update()
    {
        // Check if the number of coins is below the max and respawn if necessary
        if (GameObject.FindGameObjectsWithTag("Coin").Length < maxCoins)
        {
            SpawnCoin();
        }
    }

    private void SpawnCoin()
    {
        // Generate a random position within the defined spawn area
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            1f,
            Random.Range(-spawnArea.z, spawnArea.z)
        );

        // Instantiate the coin prefab at the random position
        Instantiate(coinPrefab, randomPosition, Quaternion.identity);
    }
}
