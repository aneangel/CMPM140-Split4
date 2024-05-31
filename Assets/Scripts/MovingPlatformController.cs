using UnityEngine;
using System.Collections.Generic;

public class MovingPlatformController : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();
    public float speed = 2.0f;
    private int currentTarget = 0;
    private int direction = 1; // Direction towards the next waypoint

    void Update()
    {
        if (waypoints.Count < 2)
        {
            Debug.LogError("Insufficient waypoints set on " + gameObject.name);
            return; // Exit if not enough waypoints
        }

        // Move platform towards the current target waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentTarget], speed * Time.deltaTime);

        // Check if platform has reached the current target waypoint
        if (Vector3.Distance(transform.position, waypoints[currentTarget]) < 0.1f)
        {
            // Switch direction at the end points
            if (currentTarget == waypoints.Count - 1)
                direction = -1;
            else if (currentTarget == 0)
                direction = 1;

            // Update the current target based on the direction
            currentTarget += direction;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") // Make sure your player GameObject has the tag "Player"
        {
            collision.transform.SetParent(this.transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            collision.transform.SetParent(null);
        }
    }

}
