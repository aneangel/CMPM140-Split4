using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Checkpoint[] allCheckpoints;
    private Checkpoint activeCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        // Don't sort the objects
        allCheckpoints = FindObjectsByType<Checkpoint>(FindObjectsSortMode.None);

        foreach (Checkpoint checkpoint in allCheckpoints)
        {
            checkpoint.checkpointManager = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            DeactivateAllCheckpoints();
        }
    }

    public void DeactivateAllCheckpoints()
    {
        foreach (Checkpoint checkpoint in allCheckpoints)
        {
            checkpoint.DeactivateCheckpoint();
        }
    }

    public void SetActiveCheckpoint(Checkpoint newActiveCheckpoint)
    {
        // set only the active checkpoint animations
        DeactivateAllCheckpoints();

        activeCheckpoint = newActiveCheckpoint;
    }

}
