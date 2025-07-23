using UnityEngine;
using UnityEngine.SceneManagement;

public class MoscolaDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Collider2D ovenCollider;  // Reference to the oven collider

    void Start()
    {
        // Find the Oven object by tag
        GameObject oven = GameObject.FindWithTag("Oven");
        if (oven != null)
        {
            ovenCollider = oven.GetComponent<Collider2D>();
        }
        else
        {
            Debug.LogError("Oven object not found in the scene. Make sure it has the 'Oven' tag.");
        }
    }

    void OnMouseDown()
    {
        // Start dragging Moscola when clicked
        isDragging = true;
    }

    void OnMouseUp()
    {
        // Stop dragging Moscola
        isDragging = false;

        // Check if released over the oven
        if (ovenCollider != null && ovenCollider.OverlapPoint(transform.position))
        {
            Debug.Log("Moscola placed in the oven. Transitioning to the Cooked scene.");
            SceneManager.LoadScene("Cooked"); // Load the "Cooked" scene
        }
    }

    void Update()
    {
        if (isDragging)
        {
            // Update Moscola's position to follow the mouse while dragging
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // Set z to 0 for 2D positioning
            transform.position = mousePos;
        }
    }
}
