using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Manager : MonoBehaviour
{
    //Player FSM Variabes
    enum PlayerState {Idle, Move, Jump}
    private PlayerState currentState;
    private bool currentStateCompleted; //Boolean value to determine when to start new state

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator; //For animations
    [SerializeField] private float playerMoveSpeed, playerJumpSpeed, playerAcceleration;
    [Range(0f, 1f)] [SerializeField] private float playerDrag;
    [SerializeField] private BoxCollider2D groundCheckCollider;
    [SerializeField] private LayerMask groundMask, playerMask;
    private float horizontalMovement, moveIncrement, totalHorizontalSpeed;
    private bool isGrounded;
    private string direction;

    // Start is called before the first frame update
    void Start()
    {
        playerMoveSpeed = 5f;
        playerJumpSpeed = 10f;
        playerAcceleration = 1f;
        playerDrag = 0.9f;
        direction = "right";
    }

    // Update is called once per frame
    void Update()
    {
        getPlayerInput(); //Determine Player Left-Right Movement Input
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded){ //Jump if UpArrow is pressed
            playerJump();
        }
        if(currentStateCompleted == true){ //If state is complete, switch to next state
            DetermineNewState();
        }
        UpdateState(); 
    }

    //Fixed Update is called at specific rates defined by the Unity editor
    void FixedUpdate(){
        checkIfGrounded();
        implementFriction();
        movePlayer();
        updateSpriteDirection();
    }

    //STATE MACHINE FUNCTIONS
    private void DetermineNewState(){ //Check each possible state and switch to them based on current stats
        currentStateCompleted = false; //Resetting to false to enable accessibility to next state
        if(isGrounded == true){
            if(horizontalMovement == 0){ //If not moving, must be Idle
                currentState = PlayerState.Idle;
                StartIdleState(); //Calling Entry Function
            } else{
                currentState = PlayerState.Move;
                StartMoveState();
            }
        } else{
            currentState = PlayerState.Jump;
            StartJumpState();
        }
    }

    void UpdateState(){
        switch (currentState){ //Switch runs different things depending on the currentState variable
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Move:
                UpdateMove();
                break;
            case PlayerState.Jump:
                UpdateJump();
                break;
        }
    }

    //INDIVIDUAL STATE FUNCTIONS
    private void StartIdleState(){
        Debug.Log("Idle State");
        animator.Play("NinjaFrog_Idle");
    }

    private void UpdateIdle(){
        if(horizontalMovement != 0 || isGrounded == false){ //Exit conditions
            currentStateCompleted = true;
        }
    }

    private void StartMoveState(){
        Debug.Log("Move State");
        animator.Play("NinjaFrog_Run");
    }

    private void UpdateMove(){
        float xVelocity = rb.velocity.x; //To enable staying within Move State until velocity == 0f

        if(Mathf.Abs(xVelocity) < 0.1f || isGrounded == false){
            currentStateCompleted = true;
        }
    }

    private void StartJumpState(){
        Debug.Log("Jump State");
        animator.Play("NinjaFrog_Jump");
        AudioManager.instance.player2Jump();
    }

    private void UpdateJump(){
        if(isGrounded == true){
            currentStateCompleted = true;
        }
    }

    //MOVEMENT & INPUT FUNCTIONS
    private void getPlayerInput(){ //Adjusts horizontal movement force depending on player input
        if(Input.GetKey(KeyCode.RightArrow)){ //Player will move Right when Right Arrow is pressed
            direction = "right";
            horizontalMovement = 1f;
        } else if(Input.GetKey(KeyCode.LeftArrow)){ //Player will move Left when Left Arrow is pressed
            direction = "left";
            horizontalMovement = -1f;
        } else{
            horizontalMovement = 0f;
        }
    }

    private void movePlayer(){
        if(horizontalMovement != 0){ //Apply movement if movement force != 0
            moveIncrement = horizontalMovement * playerAcceleration; //Applying acceleration if movement key is still being pressed
            totalHorizontalSpeed = Mathf.Clamp(rb.velocity.x + moveIncrement, -playerMoveSpeed, playerMoveSpeed);

            rb.velocity = new Vector2(totalHorizontalSpeed, rb.velocity.y);
        } else{ //Stop movement if no correct movement key is being pressed
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    private void updateSpriteDirection(){ //Flip Sprite to face left or right depending on current direction value
        if(direction == "right"){
            transform.localScale = new Vector2(1, 1);
        } else{ //direction == "left"
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void playerJump(){ //Adding y-force to player
        rb.velocity = new Vector2(rb.velocity.x, playerJumpSpeed);
    }

    private void checkIfGrounded(){ //If ground collider is overlapping objects in Ground Layer, make is Grounded true
        if(Physics2D.OverlapAreaAll(groundCheckCollider.bounds.min, groundCheckCollider.bounds.max, groundMask).Length > 0 || Physics2D.OverlapAreaAll(groundCheckCollider.bounds.min, groundCheckCollider.bounds.max, playerMask).Length > 0){
            isGrounded = true;
        } else{
            isGrounded = false;
        }
    }

    private void implementFriction(){ //Adding Friction to player if touching ground and no movement is being inputed
        if(isGrounded && horizontalMovement == 0 && rb.velocity.y <= 0){
            rb.velocity *= playerDrag;
        }
    }
}
