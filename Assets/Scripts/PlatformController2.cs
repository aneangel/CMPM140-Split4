using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController2 : MonoBehaviour
{
    [SerializeField] private GameObject platform1, platform2, button;
    [SerializeField] private Transform waypoint1, waypoint2;
    private float moveSpeed = 2f;
    private bool platformsComplete;

    void Start(){
        platformsComplete = false;
    }

    void FixedUpdate(){
        if(platformsComplete == false){ //Checking if platforms are in correct position
            var buttonScript = button.GetComponent<ButtonController>(); //Accessing Button Controller Script of Button
            if(buttonScript.isPressed() == true){ //Calling isPressed() function
                movePlatforms();
                if(platform1.transform.position == waypoint1.transform.position && platform2.transform.position == waypoint2.transform.position){
                    platformsComplete = true; //If waypoint position reached, no need to keep checking
                }
            }
        }
    }

    private void movePlatforms(){ //Moving platforms towards respective waypoint positions
        platform1.transform.position = Vector2.MoveTowards(platform1.transform.position, waypoint1.transform.position, moveSpeed * Time.deltaTime);
        platform2.transform.position = Vector2.MoveTowards(platform2.transform.position, waypoint2.transform.position, moveSpeed * Time.deltaTime);
    }
}
