using UnityEngine;
using UnityEngine.SceneManagement;

public class PizzaDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Collider2D peelCollider;  // Reference to the peel collider

    void Start()
    {
        // Find the Peel object by tag or directly in the scene
        GameObject peel = GameObject.FindWithTag("Peel");
        if (peel != null)
        {
            peelCollider = peel.GetComponent<Collider2D>();
        }
        else
        {
            Debug.LogError("Peel object not found in the scene. Please assign a tag to it.");
        }
    }

    void OnMouseDown()
    {
        // Start dragging the pizza object
        isDragging = true;
    }

    void OnMouseUp()
    {
        // Stop dragging the pizza object
        isDragging = false;

        // Check if released over the peel
        if (peelCollider != null && peelCollider.OverlapPoint(transform.position))
        {
            Debug.Log("Pizza placed on peel. Transitioning to the Cooking scene.");
            SceneManager.LoadScene("Cooking"); // Change to your scene's name
        }
    }

    void Update()
    {
        if (isDragging)
        {
            // Get the mouse position in world space
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // Set z to 0 for 2D positioning
            transform.position = mousePos;
        }
    }
}
