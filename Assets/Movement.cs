using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f; // Speed of movement

    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        // Set initial target position to the sprite's current position
        targetPosition = transform.position;
    }

    void Update()
    {
        // Detect left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

            isMoving = true;
        }

        // Move towards the target position if isMoving is true
        if (isMoving)
        {
            // Interpolate the position towards the target
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Stop moving if the sprite reaches the target position
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }
}