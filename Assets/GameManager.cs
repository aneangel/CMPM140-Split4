using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isGameOver, playerWin, hasKey;
    private float playerTime;

    public GameObject EndScreen;

    public GameObject YouWin;
    public GameObject YouLose;
    public PauseMenu pauseMenu;

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
        playerTime = 10; //Players have 90 seconds to win game
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == false && !pauseMenu.IsPauseMenuActive()){ //Whilst game isn't over, reduce timer
            Time.timeScale = 1;
            playerTime -= Time.deltaTime;
            if(playerTime <= 0){ //Players lose when timer reaches 0
                gameOver(false);
            }
        }
        else if (isGameOver == false && pauseMenu.IsPauseMenuActive())
        { //Whilst game isn't over, reduce timer
            Time.timeScale = 0;
            
        }
        else 
        {
            playerTime = 0;
            EndScreen.SetActive(true);
            if (playerWin == true)
            {
                YouLose.SetActive(false);
                YouWin.SetActive(true);
                Time.timeScale = 1;
            }
            else
            {
                YouLose.SetActive(true);
                YouWin.SetActive(false);
                Time.timeScale = 0;
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
