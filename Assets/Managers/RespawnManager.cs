using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager instance;
    private Vector2 player1SpawnPoint, player2SpawnPoint;
    [SerializeField] private GameObject player1, player2;
    private int playerDeaths;

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
        playerDeaths = 0;
        player1SpawnPoint = new Vector2(-7.24f, 0);
        player2SpawnPoint = new Vector2(-5.66f, 0);
    }

    public void respawnPlayers(){ //Resetting player positions to checkpoint spawn point
        playerDeaths += 1;
        player1.transform.position = player1SpawnPoint;
        player2.transform.position = player2SpawnPoint;
    }

    public void setSpawnPoint(Vector2 newPlayer1Spawn, Vector2 newPlayer2Spawn){ //Setting new spawnpoints
        player1SpawnPoint = newPlayer1Spawn;
        player2SpawnPoint = newPlayer2Spawn;
    }

    public int getPlayerDeathCount(){ //Return number of times players have died
        return playerDeaths;
    }
}
