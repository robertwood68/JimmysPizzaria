using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class DoorTransition : MonoBehaviour
{
    public string nextSceneName; // Name of the next scene to load

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered the door trigger."); // Debug message

        // Check if the player has collided with the door
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the door trigger."); // Debug message

            // Load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
