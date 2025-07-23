using UnityEngine;
using UnityEngine.SceneManagement;

public class LightbulbClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        // This function will be called when the lightbulb is clicked
        Debug.Log("Lightbulb clicked! Transitioning to End scene.");
        SceneManager.LoadScene("End"); // Load the "End" scene
    }
}
