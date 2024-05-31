using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform player1SpawnPoint, player2SpawnPoint;
    private bool isActive;
    public Animator anim;

    void OnTriggerEnter2D(Collider2D collideer){
        if(collideer.gameObject.tag == "Player" && isActive == false){
            RespawnManager.instance.setSpawnPoint(player1SpawnPoint.position, player2SpawnPoint.position);
            anim.SetBool("flagActive", true);

            isActive = true;
        }
    }
}
