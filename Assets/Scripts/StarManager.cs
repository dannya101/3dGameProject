using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public GameObject starPrefab;  // Reference to the star prefab
    public int maxStars = 1;       // Number of stars to maintain
    public Vector3 spawnArea = new Vector3(8, 0, 8);  // Define the area for spawning stars

    private void Start()
    {
        for (int i = 0; i < maxStars; i++)
        {
            SpawnStar();
        }
    }

    private void Update()
    {
        // Check if the number of stars is below the max and respawn if necessary
        if (GameObject.FindGameObjectsWithTag("Star").Length < maxStars)
        {
            SpawnStar();
        }
    }

    private void SpawnStar()
    {
        // Generate a random position within the defined spawn area
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            1f,
            Random.Range(-spawnArea.z, spawnArea.z)
        );

        // Instantiate the coin prefab at the random position
        Instantiate(starPrefab, randomPosition, starPrefab.transform.rotation);
    }
}
