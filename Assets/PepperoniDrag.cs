using UnityEngine;
using UnityEngine.SceneManagement;

public class PepperoniDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Collider2D pizzaStoneCollider;  // Reference to the pizza stone collider

    void Start()
    {
        // Find the Pizza Stone object by tag or directly in the scene
        GameObject pizzaStone = GameObject.FindWithTag("PizzaStone");
        if (pizzaStone != null)
        {
            pizzaStoneCollider = pizzaStone.GetComponent<Collider2D>();
        }
        else
        {
            Debug.LogError("PizzaStone object not found in the scene. Please assign a tag to it.");
        }
    }

    void OnMouseDown()
    {
        // Start dragging the pepperoni object
        isDragging = true;
    }

    void OnMouseUp()
    {
        // Stop dragging the pepperoni object
        isDragging = false;

        // Check if released over the pizza stone
        if (pizzaStoneCollider != null && pizzaStoneCollider.OverlapPoint(transform.position))
        {
            Debug.Log("Pepperoni placed on pizza stone. Transitioning to the PepPlaced scene.");
            SceneManager.LoadScene("PepPlaced"); // Change to your scene's name
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
