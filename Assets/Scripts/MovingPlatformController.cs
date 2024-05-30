using UnityEngine;
using System.Collections.Generic;

public class MovingPlatformController : MonoBehaviour
{
    public List<Vector3> waypoints;
    public float speed = 2.0f;
    private int currentTarget = 0;
    private int direction = 1;

    void Update()
    {
        if (waypoints.Count == 0) return;

        MoveTowardsNextWaypoint();

        // Check if the platform has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentTarget]) < 0.1f)
        {
            // Reverse direction at endpoints
            if (currentTarget == waypoints.Count - 1 || currentTarget == 0)
                direction *= -1;

            currentTarget += direction;
        }
    }

    void MoveTowardsNextWaypoint()
    {
        Vector3 targetWaypoint = waypoints[currentTarget];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
    }
}
