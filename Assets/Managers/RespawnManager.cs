using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager instance;
    private Vector2 player1SpawnPoint, player2SpawnPoint;
    [SerializeField] private GameObject player1, player2;

    void Awake(){
        if(instance == null){
            instance = this;
        } else{
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player1SpawnPoint = new Vector2(-3.94f, 0);
        player2SpawnPoint = new Vector2(0, 0);
    }

    public void respawnPlayers(){
        player1.transform.position = player1SpawnPoint;
        player2.transform.position = player2SpawnPoint;
    }

    public void setSpawnPoint(Vector2 newPlayer1Spawn, Vector2 newPlayer2Spawn){
        player1SpawnPoint = newPlayer1Spawn;
        player2SpawnPoint = newPlayer2Spawn;
    }
}
