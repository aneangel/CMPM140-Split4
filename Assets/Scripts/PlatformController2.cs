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
        if(platformsComplete == false){
            var buttonScript = button.GetComponent<ButtonController>();
            if(buttonScript.isPressed() == true){
                movePlatforms();
            }
        }
    }

    private void movePlatforms(){
        platform1.transform.position = Vector2.MoveTowards(platform1.transform.position, waypoint1.transform.position, moveSpeed * Time.deltaTime);
        platform2.transform.position = Vector2.MoveTowards(platform2.transform.position, waypoint2.transform.position, moveSpeed * Time.deltaTime);
    }
}
