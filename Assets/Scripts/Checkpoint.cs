using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform player1SpawnPoint, player2SpawnPoint;

    private bool isActive;
    public Animator anim;
    [HideInInspector]
    public CheckpointManager checkpointManager;

    void OnTriggerEnter2D(Collider2D collideer){
        if(collideer.gameObject.tag == "Player" && isActive == false){
            checkpointManager.SetActiveCheckpoint(this);

            RespawnManager.instance.setSpawnPoint(player1SpawnPoint.position, player2SpawnPoint.position);
            anim.SetBool("flagActive", true); 

            isActive = true;
        }
    }

    public void DeactivateCheckpoint()
    {
        anim.SetBool("flagActive", false);
        isActive = false;
    }
}
