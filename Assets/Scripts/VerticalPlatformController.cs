using UnityEngine;

public class VerticalPlatformController : MonoBehaviour
{
    public Vector3 lowerWaypoint;
    public Vector3 upperWaypoint;
    public float speed = 1.0f;
    private bool shouldMoveUp = false;

    void Update()
    {
        Vector3 targetWaypoint = shouldMoveUp ? upperWaypoint : lowerWaypoint;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);

        // Stops the platform when it reaches the destination
        if (transform.position == targetWaypoint)
        {
            speed = 0; // Optionally stop the movement
        }
    }

    public void MoveUp()
    {
        shouldMoveUp = true;
        speed = Mathf.Abs(speed); // Ensure the speed is positive
    }

    public void MoveDown()
    {
        shouldMoveUp = false;
        speed = Mathf.Abs(speed); // Ensure the speed is positive
    }
}
