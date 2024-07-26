using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ball : MonoBehaviour
{
    public float speed = 5.0f;  // Speed at which the ball moves
    public float randomFactor = 1.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MoveRandomlyOnZAxis();
    }

    void MoveRandomlyOnZAxis()
    {
        // Randomly determine the direction on the Z-axis
        float zDirection = Random.value < 0.5f ? -1f : 1f;

        // Set the velocity of the ball
        rb.velocity = new Vector3(0, 0, zDirection * speed);
    }

    void OnCollisionEnter(Collision other)
    {
        // Calculate new direction with randomness
        float xDirection = Random.Range(-randomFactor, randomFactor);
        float yDirection = Random.Range(-randomFactor, randomFactor);
        float zDirection = Mathf.Sign(rb.velocity.z);  // Maintain the same Z direction

        // Set the new velocity of the ball
        rb.velocity = new Vector3(xDirection, yDirection, zDirection * speed).normalized * speed;
    }

    public void ResetBall()
    {
        transform.position = new Vector3(0.136f, 1.137f, -4.358f);
    }
}
