using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isGameOver, playerWin, hasKey;
    private float playerTime;

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
        isGameOver = false;
        hasKey = false;
        playerTime = 90; //Players have 90 seconds to win game
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == false){ //Whilst game isn't over, reduce timer
            playerTime -= Time.deltaTime;
            if(playerTime <= 0){ //Players lose when timer reaches 0
                gameOver(false);
            }
        }
    }

    public void playerHasKeyTrue(){
        hasKey = true;
    }

    public bool playerHasKeyStatus(){
        return hasKey;
    }

    public bool getGameOverStatus(){
        return isGameOver;
    }

    public void gameOver(bool playerWinStatus){
        Debug.Log("GAME OVER!");
        playerWin = playerWinStatus;
        isGameOver = true;
    }

    public bool getPlayerWinStatus(){
        return playerWin;
    }

    public float getPlayerTime(){ //Returns time players have left
        return playerTime;
    }
}
