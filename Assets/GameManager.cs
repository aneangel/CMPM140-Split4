using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isGameOver, playerWin, hasKey;
    private float playerTime;
    private int keyCount;

    public GameObject EndScreen;

    public GameObject YouWin;
    public GameObject YouLose;
    public PauseMenu pauseMenu;
    [SerializeField] private GameObject returnInstructions;

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
        keyCount = 0;
        playerTime = 450; //Players have 7.5 minutes to win game
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
        keyCount += 1;
        if(keyCount == 2){ //Set to true if both keys acquired
            hasKey = true;
            returnInstructions.SetActive(true); //Display Return Instructions
            StartCoroutine(returnInstructionsOff());
        }
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

    IEnumerator returnInstructionsOff(){
        yield return new WaitForSeconds(5f); //After 5 seconds, turn off instructions
        returnInstructions.SetActive(false);
    }
}
