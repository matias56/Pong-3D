using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePaddle : MonoBehaviour
{
    public Camera mainCamera; // Assign your main camera here in the Inspector
    public float distanceFromCamera = 10.0f; // Distance from the camera to the paddle

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        MovePaddle();
    }

    void MovePaddle()
    {
        // Get the mouse position in screen space
        Vector3 mousePos = Input.mousePosition;

        // Convert the mouse position to world space
        mousePos.z = distanceFromCamera; // Set the distance from the camera
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);

        // Update the paddle's position
        transform.position = new Vector3(worldPos.x, worldPos.y, transform.position.z);
    }
}
