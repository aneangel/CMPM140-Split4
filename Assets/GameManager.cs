using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isGameOver, playerWin, hasKey;

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
    }

    // Update is called once per frame
    void Update()
    {
        
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
        playerWin = playerWinStatus;
        isGameOver = true;
    }

    public bool getPlayerWinStatus(){
        return playerWin;
    }
}
