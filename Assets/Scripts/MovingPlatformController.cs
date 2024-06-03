using UnityEngine;
using System.Collections.Generic;

public class MovingPlatformController : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();
    public float baseSpeed = 2.0f; // Base speed, adjusted based on the farthest distance
    private int currentTarget = 0;
    private float waitTime = 0.5f; // Time at the middle point
    private float waitTimer;
    private bool isWaiting = false;
    private float actualSpeed;

    void Start()
    {
        if (waypoints.Count != 2)
        {
            Debug.LogError("Each platform must have exactly two waypoints.", this);
            enabled = false;
            return;
        }
        // Calculate the maximum distance to synchronize the speed
        float maxDistance = Vector3.Distance(waypoints[0], waypoints[1]);
        actualSpeed = baseSpeed * (maxDistance / FindMaxDistanceAmongPlatforms());
    }

    public void UpdatePlatformPosition() //Function to be called by PlatformController1
    {
        if (isWaiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                waitTimer = 0f;
                isWaiting = false;
                currentTarget = 1 - currentTarget; // Toggle between 0 and 1
            }
        }
        else
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentTarget], actualSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[currentTarget]) < 0.1f)
        {
            isWaiting = true; // Start waiting when a waypoint is reached
        }
    }

    private float FindMaxDistanceAmongPlatforms()
    {
        // This method should ideally return the maximum distance of any platform to ensure synchronization.
        // You need to implement a way to get all platforms' maximum distances and return the highest.
        return Vector3.Distance(waypoints[0], waypoints[1]); // Temporary, adjust accordingly.
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Setting player to child of platform so that it'll move them with it; Works only if player lands on top of them
        if(collision.gameObject.tag == "Player" && collision.transform.position.y > this.transform.position.y){
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
