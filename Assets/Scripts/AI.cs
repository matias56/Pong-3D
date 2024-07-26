using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform ball;
    public float speed = 3;
    public float followThreshold = 0.1f;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 ballPosition = ball.position;

        // Update the target position to follow the ball only on the X-axis
        targetPosition = new Vector3(ballPosition.x, ballPosition.y, currentPosition.z);

        // Move the AI paddle towards the target position
        if (Vector3.Distance(currentPosition, targetPosition) > followThreshold)
        {
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        }
    }
}
