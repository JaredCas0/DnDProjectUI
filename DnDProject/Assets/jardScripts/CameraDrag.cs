using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 2; // Speed of camera movement
    public float zoomSpeed = 2; // Speed of camera zoom
    public float minX = -10f; // Minimum X boundary
    public float maxX = 10f; // Maximum X boundary
    public float minY = -10f; // Minimum Y boundary
    public float maxY = 10f; // Maximum Y boundary
    public float minZoom = 5f; // Minimum zoom level
    public float maxZoom = 15f; // Maximum zoom level

    private Vector3 dragOrigin; // Position of mouse click
    private bool isDragging = false; // Flag to check if dragging is in progress

    void Update()
    {
        // Zoom in/out using scroll wheel
        float zoom = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - zoom, minZoom, maxZoom);

        // Check for mouse button down
        if (Input.GetMouseButtonDown(0))
        {
            // Set flag and record the position of the click
            isDragging = true;
            dragOrigin = Input.mousePosition;
            return;
        }

        // Check for mouse button released
        if (!Input.GetMouseButton(0)) 
        {
            isDragging = false;
        }

        // Check if dragging is in progress
        if (isDragging) 
        {
            // Calculate the difference between the current mouse position and the click position
            Vector3 difference = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
            
            // Calculate horizontal and vertical movement
            float moveX = difference.x * dragSpeed;
            float moveY = difference.y * dragSpeed;
            
            // Calculate new camera position
            float newX = Mathf.Clamp(transform.position.x + moveX, minX, maxX);
            float newY = Mathf.Clamp(transform.position.y + moveY, minY, maxY);
            
            // Move the camera accordingly
            transform.position = new Vector3(newX, newY, transform.position.z);
        }
    }
}
