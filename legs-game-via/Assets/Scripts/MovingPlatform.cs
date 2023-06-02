using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform waypoint1;
    public Transform waypoint2;
    public float speed = 2f;

    private Vector3 targetPosition;

    private void Start()
    {
        // Initialize the target position to the first waypoint
        targetPosition = waypoint1.position;
    }

    private void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the platform has reached the target position
        if (transform.position == targetPosition)
        {
            // Switch to the other waypoint as the new target position
            if (targetPosition == waypoint1.position)
                targetPosition = waypoint2.position;
            else
                targetPosition = waypoint1.position;
        }
    }
}

