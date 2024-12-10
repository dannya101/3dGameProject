using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerEndScene : MonoBehaviour
{
    // The Y position threshold
    [SerializeField] private float fallThreshold = -5f;

    // Name of the scene to load
    [SerializeField] private string endSceneName = "End Scene";

    void Update()
    {
        // Check if the player's Y position is below the threshold
        if (transform.position.y <= fallThreshold)
        {
            // Switch to the end scene
            SceneManager.LoadScene(endSceneName);
        }
    }
}

