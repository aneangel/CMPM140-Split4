using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMiddle : MonoBehaviour
{
    //This is a script to determine the middle position of the players for the sake of the camera
    [SerializeField] private GameObject player1, player2;
    private Vector2 newPosition;
    private float newX, newY;

    void Start(){
        newX = 0;
        newY = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        newPosition = calculateNewPosition();
        this.transform.position = newPosition;
    }

    private Vector3 calculateNewPosition(){
        newX = (player1.gameObject.transform.position.x + player2.gameObject.transform.position.x) / 2;
        newY = (player1.gameObject.transform.position.y + player2.gameObject.transform.position.y) / 2;
        return new Vector2(newX, newY);
    }
}
